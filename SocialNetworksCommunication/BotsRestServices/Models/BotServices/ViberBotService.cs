using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;
using BotsRestServices.Models.Objects.BotsLibRequest;


namespace BotsRestServices.Models.BotServices
{
    public class ViberBotService : BaseBotService
    {
        private string entryPointClass = "ViberBots.ViberEntryPoint";
        private string entryPointMethod = "CallFunctions";
        private BotsLibRequest botsLib = new BotsLibRequest();
        private string viberAuth = "X-Viber-Auth-Token";

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

                Assembly vBot = LoadAssembly(pathToBotsLibrary);

                Type vBotType = GetSomeTypeInAssembly(vBot, entryPointClass);

                object vBotObject = GetObject(vBotType);

                MethodInfo entryMethod = vBotType.GetMethod(entryPointMethod);

                botsLib.BotId = botNumber;
                botsLib.CommandToRun = "ViberBotsStartPoint";
                botsLib.SecretKey = ctr.Request.Headers[viberAuth];
                botsLib.

                entryMethod.Invoke(vBotObject, new object[] {  } );

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string StartBot(int botNumber, Controller ctr)
        {
            try
            {
                string jsonString = ReadDataFromBrowser(ctr);

                Assembly vBot = LoadAssembly(pathToBotsLibrary);

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