using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotsRestServices.Models.BotServices;
using ServiceLibrary.Serialization;
using ServiceLibrary.Various;
using SocialNetworks.Telegramm.Objects;
using SocialNetworks.Telegramm;
using System.Text.RegularExpressions;

namespace BotsRestServices.Controllers.Bots
{
    public class TelegramController : Controller
    {
        TelegramBotService botService = new TelegramBotService();
        JsonDeserializer deserializer = new JsonDeserializer();
        JsonSerializer serializer = new JsonSerializer();

        [HttpPost]
        public ActionResult BotAnswer(int id, string key)
        {            
            return Json(botService.EntryFunction(id, key, this));
        }
    }
}