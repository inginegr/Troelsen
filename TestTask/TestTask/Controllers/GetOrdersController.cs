using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreDataBase;
using StoreDataBase.EntityDataModel;

namespace TestTask.Controllers
{
    public class GetOrdersController : Controller
    {
        private IStoreDB istoreDB;
        
        // GET: GetOrders
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Numbers = istoreDB.NumOrders;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Order orderParam)
        {
            Order retOrder = null;
            retOrder = istoreDB.GetOrderWithQueueParallel(orderParam.BuyerName, orderParam.OrderName, orderParam.OrderNumber);
            ViewBag.Numbers = istoreDB.NumOrders;
            if (retOrder.IsOrderReady)
                return View("SuccesOrder");
            else
                return View("Index", retOrder);
        }

        public GetOrdersController(IStoreDB storeDBParam)
        {
            istoreDB = storeDBParam;
        }
    }
}