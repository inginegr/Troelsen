using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using react_vid.Models;

namespace react_vid.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            InnerData ind = new InnerData
            {
                Name = "dima",
                Surname = "Sap"
            };
            return View(ind);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
