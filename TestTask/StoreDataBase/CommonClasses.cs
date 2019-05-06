using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace StoreDataBase
{
    public class ServiceClass
    {
        protected void LogToFile(string stParam)
        {
            StreamWriter stw = new StreamWriter("Log.txt");
            stw.WriteLine(stParam);
            stw.Close();
        }
    }

    //Класс для заказов, полученных от БД
    public class Order
    {
        public bool IsOrderReady { get; set; } // Обслужен ли заказ
        public string BuyerName { get; set; }
        public string OrderName { get; set; }
        public byte OrderNumber { get; set; }  // Количество товара, заказанного покупателем
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
}
