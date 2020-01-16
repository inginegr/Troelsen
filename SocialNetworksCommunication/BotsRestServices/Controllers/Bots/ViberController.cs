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
        //JsonDeserializer deserializer = new JsonDeserializer();    
        //FileService fs = new FileService();
        
        [HttpPost]
        public JsonResult BotAnswer(int id)
        {

            return Json(botService.EntryFunction(id, this));
        }

        [HttpPost]
        public JsonResult StartBot(int id)
        {
            return Json(botService.StartViberBot(id, this));
        }

        [HttpPost]
        public JsonResult ReadLog(int id)
        {
            return Json(botService.ReadLogData(this));
        }
    }
}