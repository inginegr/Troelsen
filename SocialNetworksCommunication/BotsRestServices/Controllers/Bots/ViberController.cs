using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.Configuration;
using BotsRestServices.Models.UserServices;
using BotsRestServices.Models.BotServices;


namespace BotsRestServices.Controllers.Bots
{
    public class ViberController : Controller
    {
        private string ViberAuth = "viberAuth";
        ViberBotService botService = new ViberBotService();

        [HttpPost]
        public JsonResult BotAnswer(int botNumber)
        {
            try
            {
                botService.ViberEntryPoint(botNumber, this);
                return Json(true);
            }catch(Exception ex)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public JsonResult StartBot(int botId)
        {
            return Json("sdf");
        }

        [HttpPost]
        public JsonResult StopBot(int botId)
        {
            return Json("");
        }
    }
}