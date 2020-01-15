using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;
using ServiceLibrary.Various;
using SharedObjectsLibrary;


namespace BotsRestServices.Models.BotServices
{
    public class ViberBotService : BaseBotService
    {
        private string entryPointClass = "BotsLibrary.ViberBots.ViberEntryPoint";
        private string entryPointMethod = "CallFunctions";
        /// <summary>
        /// Object to exchange messages with bots library
        /// </summary>
        private string viberAuth = "X-Viber-Auth-Token";

        FileService fs = new FileService();

        /// <summary>
        /// Call entry point method of viber bot
        /// </summary>
        /// <param name="botNumber">Number of bot</param>
        /// <param name="jsonString">Json string from bot</param>
        public bool RequestToBot(int botNumber, Controller ctr, string commandToRun)
        {
            AnswerFromBot ansMessage = null;
            try
            {
                BotParameters parameters = new BotParameters();

                string jsonString = ReadDataFromBrowser(ctr);

                Assembly vBot = Assembly.LoadFrom(PathToBotsLibrary(ctr));

                Type vBotType = vBot.GetType(entryPointClass);

                object vBotObject = Activator.CreateInstance(vBotType);

                parameters.BotId = botNumber;
                parameters.CommandToRun = commandToRun;
                parameters.SecretKey = ctr.Request.Headers[viberAuth];
                parameters.JsonFromServer = jsonString;
                parameters.AdditionParameters = null;

                ansMessage = (AnswerFromBot)vBotType.InvokeMember(entryPointMethod, BindingFlags.InvokeMethod, null, vBotObject,
                    new object[] { parameters }, null);

                if (ansMessage.IsTrue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                LogData(ex.Message, ctr);
                return false;
            }
        }


        public void AnswerOnBotRequest(AnswerFromBot botAnswer)
        {
            try
            {

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}