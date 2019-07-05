using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Summary.Controllers
{
    public class MainPageController : Controller
    {
        // GET: MainPage
        public ActionResult SendPage(int id = 0)
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendRemainedAsync()
        {
            return Content("dsf sdf sd fs sfd d", "text/xml");
        }
    }
}