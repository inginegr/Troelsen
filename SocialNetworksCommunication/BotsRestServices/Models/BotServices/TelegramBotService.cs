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
        public AnswerFromBot EntryFunction(int botNumber, string key, Controller ctr)
        {
            AnswerFromBot retAns = new AnswerFromBot();
            try
            {
                BotParameters parameters = new BotParameters();

                parameters.BotId = botNumber;
                parameters.SecretKey = ParseTokenKey(key);
                parameters.JsonFromServer = ReadDataFromBrowser(ctr);
                parameters.AdditionParameters = null;
                parameters.BotObjects = null;
                parameters.BotType = BotTypes.TgBot;
                parameters.ServiceCommands = TgServiceCommands.NoCommand;

                retAns = RequestToBot(parameters, ctr);

                LogData(retAns.LogMessage, ctr);

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
        /// Parse Token incoming from bot, 
        /// </summary>
        /// <param name="token">Token of bot</param>
        /// <returns>Parsed token</returns>
        private string ParseTokenKey(string token)
        {
            try
            {
                return token.Replace("--", ":");
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}