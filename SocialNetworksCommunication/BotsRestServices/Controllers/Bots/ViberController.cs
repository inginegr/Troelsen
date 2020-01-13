using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.Configuration;
using BotsRestServices.Models.UserServices;
using BotsRestServices.Models.BotServices;
using System.Web.Hosting;
using System.IO;
using ServiceLibrary.Serialization;
using ServiceLibrary.Various;

namespace BotsRestServices.Controllers.Bots
{
    public class ViberController : Controller
    {
        ViberBotService botService = new ViberBotService();
        JsonDeserializer deserializer = new JsonDeserializer();    
        FileService fs = new FileService();

        [HttpPost]
        public JsonResult BotAnswer(int botNumber)
        {
            return Json(botService.ViberEntryPoint(botNumber, this));
        }

        [HttpPost]
        public JsonResult StartBot()
        {
            return Json(true);
        }

        [HttpPost]
        public JsonResult StopBot()
        {
            return Json(true);
        }
    }
}