using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotsRestServices.Models.BotServices;
using ServiceLibrary.Serialization;
using ServiceLibrary.Various;


namespace BotsRestServices.Controllers.Bots
{
    public class TelegramController : Controller
    {
        TelegramBotService botService = new TelegramBotService();


        [HttpGet]
        public ActionResult BotAnswer(int id)
        {
            return Json(botService.EntryFunction(id,this));
        }

    }
}
