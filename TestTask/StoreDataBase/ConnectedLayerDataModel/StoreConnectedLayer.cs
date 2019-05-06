using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDataBase.EntityDataModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;



namespace StoreDataBase.ConnectedLayerDataModel
{
    // Parameters of table, while created new in database
    class TableDataBase
    {
        public string NameColumn { get; set; }
        public string ColumnType { get; set; }
        public string CreateParams { get; set; }
        public string ParamColumn { get; set; }
    }

    
    public partial class StoreConnectedLayer : ServiceClass, IStoreDB
    {
        // Остаток товара
        private int? numOrders;
        public int? NumOrders { get { lock (BlockNumOrder) { return numOrders; } } set { lock (BlockNumOrder) { numOrders = value; } } }

        //Маркеры блокировки
        private object BlockQueue { get; set; }
        private object BlockDB { get; set; }
        private object BlockNumOrder { get; set; }

        //Очередь заказов на обслуживание
        private Queue<Order> orderCollectionToServe { get; set; }

        //Коллекция обслуженных заказов
        private List<Order> orderCollectionServed { get; set; }


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

        public Order GetOrderWithQueueSerial(string NameOfBuyer, string NameOfGoods, byte GoodsNumber)
        {
            throw new NotImplementedException();
        }

        public bool InsertOrder(Order orderParam)
        {
            throw new NotImplementedException();
        }

        // Метод для извлечения заказов из БД
        private void GetOrdersFromDB(Queue<Order> ordersParam)
        {

            // Временная коллекция для обслуженных заказов
            List<Order> _tmpOrderServed = new List<Order>();

            SqlConnection sqlConnection = null;

            //Вычилсяем общее число заказов, поставленных в очередь
            int totalNumberOfOrders = ordersParam.Sum(e => e.OrderNumber);
            try
            {

                // Make SQL Connection
                sqlConnection = new SqlConnection(ConnectionStringStoreDB);
                sqlConnection.Open();
                sqlConnection.ChangeDatabase(DataBaseName);

                // Total number of goods remained
                int? remainedGoods = int.Parse(SelectParamFromDB(sqlConnection).First());

                //Обслуживаем каждый заказ, поставленный в очередь           
                while (ordersParam.Count != 0)
                {
                    Order tmpOrder = ordersParam.Dequeue();
                    if ((remainedGoods - tmpOrder.OrderNumber) >= 0) //Если баланс не отрицательный, то бронируем заказ
                    {
                        remainedGoods -= tmpOrder.OrderNumber;
                        tmpOrder.IsOrderReady = true;
                        _tmpOrderServed.Add(tmpOrder); // Заносим заказ в список обслуженных

                        // Заносим покупателей в БД
                        InsertIntoDBTable("Buyers", sqlConnection, new TableDataBase { NameColumn = "BuyerName", ParamColumn = tmpOrder.BuyerName },
                            new TableDataBase { NameColumn = "BuyerGoods", ParamColumn = tmpOrder.OrderName },
                            new TableDataBase { NameColumn = "GoodsNumber", ParamColumn = tmpOrder.OrderNumber.ToString() });
                    }
                    else //Если баланс отрицательный, то всем остальным заказам присваиваем статус "false" и помещаем в коллекцию обслуженных (false установлен по умолчанию в конструкторе)
                    {
                        _tmpOrderServed.Add(tmpOrder);
                    }
                }

                UpdateDataInDB("Goods", "GoodsID", 1, "GoodsRemain", (int)remainedGoods, sqlConnection);



                // Переносим результат в коллекцию обслуженных заказов
                foreach (Order o in _tmpOrderServed)
                {
                    o.GoodsRemain = remainedGoods;
                    orderCollectionServed.Add(o);
                }

                numOrders = remainedGoods;
            }
            catch (Exception ex)
            {
                LogToFile(ex.Message);
                sqlConnection.Close();
            }
            finally
            {
                CloseDataBaseConnection(sqlConnection);
            }
        }
    }
}
