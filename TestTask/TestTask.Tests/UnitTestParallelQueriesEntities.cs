using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StoreDataBase.EntityDataModel;
using StoreDataBase;
using StoreDataBase.ConnectedLayerDataModel;

namespace TestTask.Tests
{
    [TestClass]
    public class StoreDBTest
    {
        private delegate Order StartQueriesDelegate(string BuyerName, string GoodsName, byte GoodsNumber, StoreDBEntities sdb);
        private StartQueriesDelegate StartQueries = new StartQueriesDelegate(StartQueriesMethod);
        List<Order> ServedOrderCollection = new List<Order>();
        private object BlockServedOrderCollection = new object();
        private AutoResetEvent finishOfQueriesFlag = new AutoResetEvent(false);

        [TestMethod]
        public void EmptyDbTable_ByManyThreads_UsingQueue()
        {
            StoreDBEntities storeDB = new StoreDBEntities(); 

            // Формируем коллекцию заказов для запросов к БД
            List<Order> ordersToServe = new List<Order>();
            Random rn = new Random();
            for (int i = 0; i < 1000; i++)
                ordersToServe.Add(new Order() { BuyerName = $"Byuer Number {i}", OrderName = "Some order", OrderNumber = (byte)rn.Next(1, 5) });

            // Запускаем запросы к БД в асинхронном режиме
            foreach (Order o in ordersToServe)
                StartQueries.BeginInvoke(o.BuyerName, o.OrderName, o.OrderNumber, storeDB, new AsyncCallback(StartQueriesFinish), null);

            finishOfQueriesFlag.WaitOne();

            // Проверяем, что сумма купленных товаров, равноа 100
            Assert.AreEqual(100, ServedOrderCollection.Where(o=>o.IsOrderReady==true).Sum(o => o.OrderNumber));
        }


        private static Order StartQueriesMethod(string BuyerName, string GoodsName, byte GoodsNumber, StoreDBEntities sdb)
        {
            return sdb.GetOrderWithQueueParallel(BuyerName, GoodsName, GoodsNumber);
        }

        private void StartQueriesFinish(IAsyncResult iar)
        {
            AsyncResult ar = (AsyncResult)iar;
            StartQueriesDelegate sq = (StartQueriesDelegate)ar.AsyncDelegate;
            // Add served order to collection of served orders
            lock (BlockServedOrderCollection)
            {
                ServedOrderCollection.Add(sq.EndInvoke(iar));
                if (ServedOrderCollection.Count == 1000)
                    finishOfQueriesFlag.Set();
            }            
        }
    }
}
