using SharedObjectsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BotsRestServices.Models.BotServices
{
    public class TelegramBotService : BaseBotService
    {
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
                parameters.CommandToRun = "EnterPointMethod";
                parameters.SecretKey = "";
                parameters.JsonFromServer = ReadDataFromBrowser(ctr);
                parameters.AdditionParameters = null;
                parameters.BotObjects = null;
                parameters.BotType = BotTypes.TgBot;

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
    }
}