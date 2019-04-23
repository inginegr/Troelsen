using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to a url to show an example";
        }

        public ViewResult AutoProperty()
        {
            Product prod = new Product() { Name = "Kayak", Category = "Categ", Price = 23, Description = "Descr", ProductID = 2 };

            return View("Result", (object)String.Format("Product name is: {0}", prod.Name));
        }
    }
}