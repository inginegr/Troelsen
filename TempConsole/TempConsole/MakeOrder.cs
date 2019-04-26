using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.Data.Objects;

namespace TempConsole
{
    //Класс для заказов, полученных от БД
    class Order
    {
        public bool IsOrderReady { get; set; } // Обслужен ли заказ
        public string BuyerName { get; set; }
        public string OrderName { get; set; }
        public byte OrderNumber { get; set; }
        public int? GoodsRemain { get; set; }  // Количество товара, оставшееся в БД

        public Order()
        {
            IsOrderReady = false;
            GoodsRemain = null;
        }
        public Order(string buyerName, string orderName, byte num)
        {
            IsOrderReady = false;
            GoodsRemain = null;
            BuyerName = buyerName;
            OrderName = orderName;
            OrderNumber = num;
        }
    }


    public class MakeOrder
    {        
        //Флаги
        bool IsDBInUse { get; set; } //Происходит ли обращение к БД в данный момент для извлечения заказов
        bool IsQueueEmpty { get; set; } //Если очередь е пуста, то необходимо еще раз запустить метод извлечения заказов из БД

        //Маркеры блокировки
        object BlockQueue { get; set; }
        object BlockDB { get; set; }
        
        private Entity ProjectDB { get; set; }

        //Очередь заказов на обслуживание
        private Queue<Order> orderCollectionToServe { get; set; }
        //Очередь событий для синхронизации
        private Queue<AutoResetEvent> waitEvents { get; set; }
        //Коллекция обслуженных заказов
        private List<Order> orderCollectionServed { get; set; }


        //Делегат для асинхронного извлечения заказов из БД
        private delegate void GetFromDBDelegate();
        private GetFromDBDelegate GetDataFromDb { get; set; }


        // Метод для обслуживания заказов
        public bool GetOrder(string NameOfBuyer, string NameOfGoods, byte GoodsNumber)
        {
            //Создаем евент для синхронизации
            AutoResetEvent insideThreadWait = new AutoResetEvent(false);

            //Вносим заказ в очередь для извлечения из БД
            lock (BlockQueue)
            {
                orderCollectionToServe.Enqueue(new Order { BuyerName = NameOfBuyer, OrderName = NameOfGoods, OrderNumber = GoodsNumber });
                waitEvents.Enqueue(insideThreadWait);
                if (!IsDBInUse)
                {
                    IsDBInUse = true;                    
                    GetDataFromDb.BeginInvoke(null, null);
                }else if (IsQueueEmpty)
                {
                    IsQueueEmpty = false;
                    GetDataFromDb.BeginInvoke(null, null);
                }
            }
            
            //Ожидаем, пока заказ поставленный в очередь не обслужится
            insideThreadWait.WaitOne();

            //Извлекаем из БД все заказы, поставленные в очередь
            return true;
        }

        private void GetOrdersFromDB(Queue<AutoResetEvent> waitEventParam, Queue<Order> ordersParam)
        {
            //Вычилсяем общее число заказов
            int totalNumberOfOrders = ordersParam.Sum(e => e.OrderNumber);

            //Какое количество заказов осталось в БД
            Goods goods = ProjectDB.Goods.Find(1);

            //Обслуживаем каждый заказ, поставленный в очередь           
            while (ordersParam.Count!=0)
            {
                Order tmpOrder = ordersParam.Dequeue();
                if ((goods.GoodsBalance - tmpOrder.OrderNumber) >= 0) //Если баланс не отрицательный, то бронируем заказ
                {
                    goods.GoodsBalance -= ordersParam.Dequeue().OrderNumber;
                    tmpOrder.IsOrderReady = true;
                    orderCollectionServed.Add(tmpOrder);  // Заносим заказ в список обслуженных
                    // Заносим покупателей в БД
                    ProjectDB.Byuers.Add(new Buyers { BuyerName = tmpOrder.BuyerName, BuyerNumberOfOrders = tmpOrder.OrderNumber });
                }
                else //Если баланс отрицательный, то всем остальным заказам присваиваем статус "false" и помещаем в коллекцию обслуженных (false установлен по умолчанию в конструкторе)
                    orderCollectionServed.Add(tmpOrder);
            }

            // Заносим в ответ количество товаров, оставшихся в БД
            foreach (Order o in orderCollectionServed)
                o.GoodsRemain = goods.GoodsBalance;

            //Вносим изменения в БД
            ProjectDB.SaveChanges();

            //Запускаем потоки, ожидающие обслуженных заказов
            while (waitEventParam.Count != 0)
                waitEventParam.Dequeue().Set();

            lock (BlockQueue)
            {
                IsDBInUse = false;
            }
        }

        private void GetFromDBManage()
        {
            Queue<Order> _localOrderCollection = null;
            Queue<AutoResetEvent> _localResetEventCollection = null;
            lock (BlockDB)
            {
                lock (BlockQueue)
                {
                    _localOrderCollection = LocalOrdersCopyReturn(orderCollectionToServe);
                    _localResetEventCollection = LocalWaitEventCopyReturn(waitEvents);
                    IsQueueEmpty = true;
                }
                GetOrdersFromDB(_localResetEventCollection, _localOrderCollection);
            }            

            // Копия заказов
            Queue<Order> LocalOrdersCopyReturn(Queue<Order> orderParam)
            {
                Queue<Order> orders = new Queue<Order>();
                while (orderParam.Count != 0)
                    orders.Enqueue(orderParam.Dequeue());
                return orders;
            }

            // Копия Wait'ов
            Queue<AutoResetEvent> LocalWaitEventCopyReturn(Queue<AutoResetEvent> waitParam)
            {
                Queue<AutoResetEvent> waitEvents = new Queue<AutoResetEvent>();
                while (waitParam.Count != 0)
                    waitEvents.Enqueue(waitParam.Dequeue());
                return waitEvents;
            }
        }

        //public void TempAdd(string st, byte bt)
        //{
        //    orderCollection.Add(new Order(st, bt));
        //}

        public MakeOrder()
        {
            //Инициализируем флаги
            IsDBInUse = false;
            IsQueueEmpty = false; ;

            //Инициализируем блокирвки
            BlockQueue = new object();
            BlockDB = new object();
            
            //Инициализируем базу данных
            Database.SetInitializer(new InitialiseGoods());
            ProjectDB = new Entity();
            ProjectDB.Database.Initialize(true);

            orderCollectionToServe = new Queue<Order>();
            waitEvents = new Queue<AutoResetEvent>();
            orderCollectionServed = new List<Order>();

            GetDataFromDb = new GetFromDBDelegate(GetFromDBManage);
        }
    }
}
