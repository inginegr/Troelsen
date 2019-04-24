using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;
using Ninject.Web.Common;
using TempLibrary;


namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;
        private Products[] prods =
        {
            new Products{ ProductID=0, Category="Meat", Description="The covered meat", Name="Sousage", Price=239},
            new Products{ ProductID=1, Category="Milk", Description="Sour milk", Name="Kefir", Price=52},
            new Products{ ProductID=2, Category="Milk", Description="The cow's milk", Name="Milk", Price=49},
            new Products{ ProductID=3, Category="Chocolate", Description="Sweet item", Name="Snikers", Price=32}
        };

        private ITestCount itst;

        public HomeController(IValueCalculator clc1, ITestCount its)
        {
            calc = clc1;
            itst = its;
        }

        // GET: Home
        public ActionResult Index()
        {            
            ShoppingCart shopCard = new ShoppingCart(calc) { Prods = prods };

            itst.IncreaseCount();
            ViewBag.Cntr = itst.GetCounter();

            decimal totalValue = shopCard.CalculateProductTotal();

            return View(totalValue);
        }
    }
}