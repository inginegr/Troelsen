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


        /// <summary>
        /// Handle requests from Telegram server
        /// </summary>
        /// <param name="id">Bot number</param>
        /// <param name="key">Token of Telegram Bot. Token is coming with ":" sign changed by "--" sign. 
        /// If you want to use it, it is neccassary to replace all "--" signs to ":"</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BotAnswer(int id, string key)
        {            
            return Json(botService.EntryFunction(id, key, this));
        }

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
    }
}