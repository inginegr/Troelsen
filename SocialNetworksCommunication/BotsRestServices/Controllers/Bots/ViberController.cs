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
                //Response.Headers.Add("X-Viber-Content-Signature", Request.Headers["X-Viber-Content-Signature"]);
                string st = Regex.Replace(ans.LogMessage, "\\r|\\n", "");
                
                Response.Output.Write(st);
                return Json(HttpStatusCode.OK);
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


        public class MessageSender
        {
            public string name { get; set; }
            public string avatar { get; set; }
        }

        public class MessageBasic
        {
            public MessageSender sender { get; set; }
            public string tracking_data { get; set; }
            public string type { get; set; }
            public MessageBasic()
            {
                sender = new MessageSender();
            }
        }

        private class EventViber
        {
            public string Event { get; set; }
        }

        public class ConversationStartedMessage :MessageBasic
        {
            public string text { get; set; }
            public string media { get; set; }
            public string thumbnail { get; set; }
        }

        [HttpPost]
        public ActionResult ConvStart(int id)
        {
            string jsonAnswer = string.Empty;

            JsonDeserializer deserializer = new JsonDeserializer();
            JsonSerializer serializer = new JsonSerializer();

            string jsonPostData = string.Empty;

            using (Stream sr = Request.InputStream)
            {
                sr.Position = 0;
                using (StreamReader rd = new StreamReader(sr))
                {
                    jsonPostData = rd.ReadToEnd();
                }
            }


            EventViber viberEvent = null;
            if (jsonPostData != "" && jsonPostData != null)
            {
                viberEvent = deserializer.DeserializeToObjectT<EventViber>(jsonPostData);

                // If event not null and empty then it is callback message
                if (viberEvent.Event != null && viberEvent.Event != "")
                {
                    if (viberEvent.Event == "conversation_started")
                    {
                        ConversationStartedMessage mes = new ConversationStartedMessage();

                        Response.Headers.Add("X-Viber-Content-Signature", Request.Headers["X-Viber-Content-Signature"]);

                        mes.media = "";
                        mes.sender.avatar = "";
                        mes.sender.name = "";
                        mes.thumbnail = "";
                        mes.tracking_data = "";

                        mes.text = "Hello";
                        mes.type = "text";

                        jsonAnswer = serializer.SerializeObjectT(mes);
                    }
                }
            }
            Response.Output.Write(Regex.Replace(jsonAnswer , "\\r|\\n", ""));
            return null;
        }
    }
}