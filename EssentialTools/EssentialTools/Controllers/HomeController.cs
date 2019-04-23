using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;
using Ninject.Web.Common;

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

        public HomeController(IValueCalculator clc1, IValueCalculator clc2)
        {
            calc = clc1;
        }

        // GET: Home
        public ActionResult Index()
        {            
            ShoppingCart shopCard = new ShoppingCart(calc) { Prods = prods };

            decimal totalValue = shopCard.CalculateProductTotal();

            return View(totalValue);
        }
    }
}