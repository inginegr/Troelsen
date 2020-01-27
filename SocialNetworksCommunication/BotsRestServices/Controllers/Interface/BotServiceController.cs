using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotsRestServices.Models.UserServices;


namespace BotsRestServices.Controllers.Interface
{

    public class BotServiceController : Controller
    {
        BotsHandleService bh = new BotsHandleService();
        [HttpPost]
        public ActionResult StartBot()
        {
            return Json(bh.StartBots(this));
        }

        [HttpPost]
        public ActionResult StopBot()
        {
            return Json(bh.StopBots(this));
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