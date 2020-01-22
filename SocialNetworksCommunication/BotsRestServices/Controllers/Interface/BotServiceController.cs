using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BotsRestServices.Controllers.Interface
{
    public class BotServiceController : Controller
    {
        [HttpPost]
        public ActionResult StartBot()
        {
            return Json("");
        }

        [HttpPost]
        public ActionResult StopBot()
        {
            return Json("");
        }

        [HttpPost]
        public ActionResult AddObjectToBot()
        {
            return Json("");
        }

        [HttpPost]
        public ActionResult DeleteObjectFromBot()
        {
            return Json("");
        }

        [HttpPost]
        public ActionResult EditBotObject()
        {
            return Json("");
        }
    }
}