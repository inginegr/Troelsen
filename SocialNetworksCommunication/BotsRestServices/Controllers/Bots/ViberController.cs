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
using System.Net;
using SharedObjectsLibrary;
using System.Text.RegularExpressions;

namespace BotsRestServices.Controllers.Bots
{
    public class ViberController : Controller
    {
        ViberBotService botService = new ViberBotService();
        //JsonDeserializer deserializer = new JsonDeserializer();    
        //FileService fs = new FileService();
        
        [HttpPost]
        public ActionResult BotAnswer(int id)
        {
            AnswerFromBot ans = botService.EntryFunction(id, this);
                        
            if(ans.IsTrue)
            {
                Response.Headers.Add("X-Viber-Content-Signature", Request.Headers["X-Viber-Content-Signature"]);
                Response.Headers.Add("X-Viber-Auth-Token", Request.Headers["X-Viber-Auth-Token"]);
                string st = Regex.Replace(ans.LogMessage, "\\r|\\n", "");
                return Json(st);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(false);
            }
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