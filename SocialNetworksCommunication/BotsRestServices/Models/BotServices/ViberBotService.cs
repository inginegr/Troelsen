using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;
using ServiceLibrary.Various;
using SharedObjectsLibrary;
using System.Text.RegularExpressions;

namespace BotsRestServices.Models.BotServices
{
    public class ViberBotService : BaseBotService
    {        
        /// <summary>
        /// Object to exchange messages with bots library
        /// </summary>
        private string viberAuth = "X-Viber-Auth-Token";


        FileService fs = new FileService();

        /// <summary>
        /// Start function to all bots
        /// </summary>
        /// <param name="botNumber">Id of bot</param>
        /// <param name="ctr">Controller</param>
        public AnswerFromBot EntryFunction(int botNumber, Controller ctr)
        {
            AnswerFromBot retAns = new AnswerFromBot();
            try
            {
                BotParameters parameters = new BotParameters();

                parameters.BotId = botNumber;
                parameters.CommandToRun = "BotsStartPoint";
                parameters.SecretKey = ctr.Request.Headers[viberAuth];
                parameters.JsonFromServer = ReadDataFromBrowser(ctr);
                parameters.AdditionParameters = null;
                parameters.BotObjects = null;
                parameters.BotType = BotTypes.ViberBot;

                retAns = RequestToBot(parameters, ctr);
                return retAns;
            }
            catch (Exception ex)
            {
                LogData(ex.Message, ctr);
                retAns.IsTrue = false;
                retAns.LogMessage = ex.Message;
                return retAns;
            }
        }

        

        /// <summary>
        /// Start viber bot ans listen messages
        /// </summary>
        /// <param name="botId">Number of bot</param>
        /// <param name="ctr">Controller</param>
        /// <returns>True if success, else false</returns>
        //public bool StartViberBot(int botId, Controller ctr)
        //{
        //    try
        //    {
        //        BotParameters botParams = new BotParameters();

        //        botParams.BotId = botId;
        //        botParams.CommandToRun = "StartBot";
        //        botParams.SecretKey = "4a7c5ca68627d7fa-7c9131063c57af80-1c15e271750463a8";

        //        ViberSetWebHook setWebHook = new ViberSetWebHook() { url = "https://fbszk.icu/Viber/BotAnswer/1",
        //            event_types =new string[] { "delivered", "seen", "failed", "subscribed", "unsubscribed", "conversation_started" },
        //            send_name = true,
        //            send_photo = true
        //        };

        //        botParams.AdditionObject = setWebHook;
                
        //        AnswerFromBot ans = RequestToBot(botParams, ctr);
        //        return ans.IsTrue;
        //    }catch(Exception ex)
        //    {
        //        LogData(ex.Message, ctr);
        //        return false;
        //    }
        //}
        
    }
}