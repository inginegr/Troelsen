using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;
using BotsRestServices.Models.Objects.BotsLibRequest;
using ServiceLibrary.Various;


namespace BotsRestServices.Models.BotServices
{
    public class ViberBotService : BaseBotService
    {
        private string entryPointClass = "ViberBots.ViberEntryPoint";
        private string entryPointMethod = "CallFunctions";
        /// <summary>
        /// Object to exchange messages with bots library
        /// </summary>
        private BotsLibRequest botsLib = new BotsLibRequest();
        private string viberAuth = "X-Viber-Auth-Token";

        FileService fs = new FileService();

        /// <summary>
        /// Do basic settings request to bots livrary
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="botNumber"></param>
        /// <param name="ctr"></param>
        /// <returns></returns>
        private BotsLibRequest BasicRequestSet(BotsLibRequest lib, int botNumber, Controller ctr)
        {
            lib.BotId = botNumber;
            lib.SecretKey = ctr.Request.Headers[viberAuth];
            return lib;
        }

        /// <summary>
        /// Call entry point method of viber bot
        /// </summary>
        /// <param name="botNumber">Number of bot</param>
        /// <param name="jsonString">Json string from bot</param>
        public void ViberEntryPoint(int botNumber, Controller ctr)
        {
            try
            {
                string jsonString = ReadDataFromBrowser(ctr);

                Assembly vBot = LoadAssembly(PathToBotsLibrary());

                Type vBotType = GetSomeTypeInAssembly(vBot, entryPointClass);

                object vBotObject = Activator.CreateInstance(vBotType);
                
                botsLib.BotId = botNumber;
                botsLib.CommandToRun = "ViberBotsStartPoint";
                botsLib.SecretKey = ctr.Request.Headers[viberAuth];
                botsLib.JsonFromServer = jsonString;

                BotsLibRequest answerFromLib = (BotsLibRequest)vBotType.
                    InvokeMember(entryPointMethod, BindingFlags.InvokeMethod, null, vBotObject, new object[] { botsLib }, null);
            }
            catch(Exception ex)
            {
                LogData(ex.Message, ctr);
            }
        }

        public string StartBot(int botNumber, Controller ctr)
        {
            try
            {
                string jsonString = ReadDataFromBrowser(ctr);

                Assembly vBot = LoadAssembly(PathToBotsLibrary());

                Type vBotType = GetSomeTypeInAssembly(vBot, entryPointClass);

                object vBotObject = GetObject(vBotType);

                MethodInfo entryMethod = vBotType.GetMethod(entryPointMethod);

                entryMethod.Invoke(vBotObject, new object[] { botNumber, jsonString, "StartBot" });

                return "";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}