using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace StoreDataBase.EntityDataModel
{
    
    public class StoreDBEntities : IStoreDB
    {
        // Остаток товара
        private int? numOrders;
        public int? NumOrders { get { lock (BlockNumOrder) { return numOrders; } } set { lock (BlockNumOrder) { numOrders = value; } } }
        //Маркеры блокировки
        private object BlockQueue { get; set; }
        private object BlockDB { get; set; }
        private object BlockNumOrder { get; set; }

        private DBEntities ProjectDB { get; set; }

        //Очередь заказов на обслуживание
        private Queue<Order> orderCollectionToServe { get; set; }

        //Коллекция обслуженных заказов
        private List<Order> orderCollectionServed { get; set; }

        // Метод для обслуживания заказов
        public Order GetOrderWithQueueParallel(string NameOfBuyer, string NameOfGoods, byte GoodsNumber)
        {
            Order servedOrder = null; // Возвращаемое значение
            // Local temp collections
            Order _localOrderToServe = null;

            // Блокируем логику добавления заказов в очередь на обслуживание
            lock (BlockQueue)
            {
                _localOrderToServe = new Order() { BuyerName = NameOfBuyer, OrderName = NameOfGoods, OrderNumber = GoodsNumber };
                orderCollectionToServe.Enqueue(_localOrderToServe);
            }

            // Блокируем  логику извлечения заказов из ДБ
            lock (BlockDB)
            {

                // Если данного заказа нет в коллекции обслуженных, то запускаем логику извлечения заказов из БД\\
                if (!orderCollectionServed.Exists(o => o == _localOrderToServe))
                {
                    Queue<Order> tmpOrdersQueue = null;
                    lock (BlockQueue)
                    {
                        //  Опусташаем очередь заказов, поставленных на обслуживание
                        tmpOrdersQueue = LocalOrdersCopyReturn(orderCollectionToServe);
                    }
                    GetOrdersFromDB(tmpOrdersQueue);
                }
                // Извлекаем заказ из коллекции обслуженных заказов
                servedOrder = orderCollectionServed.Find(x => x == _localOrderToServe);
                orderCollectionServed.Remove(servedOrder);

                return servedOrder;
            }

            // Копия заказов
            Queue<Order> LocalOrdersCopyReturn(Queue<Order> orderParam)
            {
                Queue<Order> orders = new Queue<Order>();
                while (orderParam.Count != 0)
                    orders.Enqueue(orderParam.Dequeue());
                return orders;
            }
        }


        // Метод для извлечения заказов из БД
        private void GetOrdersFromDB(Queue<Order> ordersParam)
        {
            
            // Временная коллекция для обслуженных заказов
            List<Order> _tmpErderServed = new List<Order>();

            //Вычилсяем общее число заказов, поставленных в очередь
            int totalNumberOfOrders = ordersParam.Sum(e => e.OrderNumber);

            // Получаем товар, извлекаемый из БД
            Goods goods = ProjectDB.Goods.Find(1);

            //Обслуживаем каждый заказ, поставленный в очередь           
            while (ordersParam.Count != 0)
            {
                Order tmpOrder = ordersParam.Dequeue();
                if ((goods.GoodsBalance - tmpOrder.OrderNumber) >= 0) //Если баланс не отрицательный, то бронируем заказ
                {
                    goods.GoodsBalance -= tmpOrder.OrderNumber;
                    tmpOrder.IsOrderReady = true;
                    _tmpErderServed.Add(tmpOrder); // Заносим заказ в список обслуженных
                    // Заносим покупателей в БД
                    ProjectDB.Byuers.Add(new Buyers { BuyerName = tmpOrder.BuyerName, BuyerNumberOfOrders = tmpOrder.OrderNumber });
                }
                else //Если баланс отрицательный, то всем остальным заказам присваиваем статус "false" и помещаем в коллекцию обслуженных (false установлен по умолчанию в конструкторе)
                {
                    _tmpErderServed.Add(tmpOrder);
                }
            }

            // Переносим результат в коллекцию обслуженных заказов
            foreach (Order o in _tmpErderServed)
            {
                o.GoodsRemain = goods.GoodsBalance;
                orderCollectionServed.Add(o);
            }

            NumOrders = goods.GoodsBalance;

            //Вносим изменения в БД
            ProjectDB.SaveChanges();
        }

        public Order GetOrderWithQueueSerial(string NameOfBuyer, string NameOfGoods, byte GoodsNumber)
        {
            Order ord = new Order() { BuyerName = NameOfBuyer, OrderName = NameOfGoods, OrderNumber = GoodsNumber };
            lock (BlockDB)
            {
                // Получаем товар, извлекаемый из БД
                Goods goods = ProjectDB.Goods.Find(1);


                if ((goods.GoodsBalance - GoodsNumber) >= 0) //Если баланс не отрицательный, то бронируем заказ
                {
                    goods.GoodsBalance -= GoodsNumber;
                    ord.IsOrderReady = true;
                    orderCollectionServed.Add(ord); // Заносим заказ в список обслуженных
                    // Заносим покупателей в БД
                    ProjectDB.Byuers.Add(new Buyers { BuyerName = ord.BuyerName, BuyerNumberOfOrders = ord.OrderNumber });
                    ord.GoodsRemain = goods.GoodsBalance;
                    //Вносим изменения в БД
                    ProjectDB.SaveChanges();
                }
                else //Если баланс отрицательный, то присваиваем статус "false" (false установлен по умолчанию в конструкторе)
                {
                    orderCollectionServed.Add(ord);
                }
                NumOrders = goods.GoodsBalance;
            }
            return ord;
        }

        public bool InsertOrder(Order orderParam)
        {
            bool retBool = true;
            lock (BlockDB)
            {
                try
                {
                    // Получаем товар, извлекаемый из БД
                    Goods goods = ProjectDB.Goods.Find(1);

                    goods.GoodsBalance += orderParam.OrderNumber;
                    //Вносим изменения в БД
                    ProjectDB.SaveChanges();

                    NumOrders = goods.GoodsBalance;
                }
                catch (Exception)
                {
                    retBool = false;
                }
            }
            return retBool;
        }

        public StoreDBEntities()
        {            
            //Инициализируем блокирвки
            BlockQueue = new object();
            BlockDB = new object();
            BlockNumOrder = new object();

            //Инициализируем базу данных
            Database.SetInitializer(new InitialiseGoods());
            ProjectDB = new DBEntities();
            ProjectDB.Database.Initialize(true);

            orderCollectionToServe = new Queue<Order>();
            orderCollectionServed = new List<Order>();

            NumOrders = GetOrderWithQueueParallel("fake", "fake", 0).GoodsRemain;
        }
    }
}
