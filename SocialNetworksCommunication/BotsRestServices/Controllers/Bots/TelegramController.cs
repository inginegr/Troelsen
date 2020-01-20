using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotsRestServices.Models.BotServices;
using ServiceLibrary.Serialization;
using SocialNetworks.Telegramm.Objects;
using SocialNetworks.Telegramm;
using ServiceLibrary.Various;


namespace BotsRestServices.Controllers.Bots
{
    public class TelegramController : Controller
    {
        BaseBotService botService = new BaseBotService();
        JsonSerializer serializer = new JsonSerializer();
        JsonDeserializer deserializer = new JsonDeserializer();
        InternetService isserv = new InternetService();

        [HttpGet]
        public ActionResult BotAnswer1(string id)
        {
            //TgUpdate st = deserializer.DeserializeToObjectT<TgUpdate>(botService.ReadDataFromBrowser(this));


            botService.LogData(id, this);
            return Json(true);
        }
        // GET: Tg
        [HttpPost]
        public ActionResult BotAnswer(string id)
        {
            string rets = string.Empty;
            try
            {
                TgUpdate st = deserializer.DeserializeToObjectT<TgUpdate>(botService.ReadDataFromBrowser(this));
                botService.LogData(st.ToString(), this);
                TgCommunicate tg = new TgCommunicate("770611690:AAHMqfL8St-CpbznDD1ObU0XJZs3xv5q2e0");
                TgMessageToSend tgm = new TgMessageToSend() { chat_id = st.message.chat.id, text = "Hello *friend*", parse_mode="Markdown" };
                string jss = serializer.SerializeObjectT(tgm);
                botService.LogData(jss, this);
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers["Content-Type"] = "application/json";

                isserv.SendPostInternetRequest(jss, "https://api.telegram.org/bot770611690:AAHMqfL8St-CpbznDD1ObU0XJZs3xv5q2e0/sendMessage", headers);
                //string s = isserv.SendGetInternetRequest("https://api.telegram.org/bot770611690:AAHMqfL8St-CpbznDD1ObU0XJZs3xv5q2e0/getme");

                //botService.LogData(s, this);
            }
            catch(Exception ex)
            {
                botService.LogData(ex.Message, this);
            }


            return Json(true);
        }
        
    }
}
