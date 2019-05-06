using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDataBase.EntityDataModel;

namespace StoreDataBase
{
    public interface IStoreDB
    {
        Order GetOrderWithQueueParallel(string NameOfBuyer, string NameOfGoods, byte GoodsNumber);
        Order GetOrderWithQueueSerial(string NameOfBuyer, string NameOfGoods, byte GoodsNumber);
        bool InsertOrder(Order orderParam);
        int? NumOrders { get; set; }
    }
}
