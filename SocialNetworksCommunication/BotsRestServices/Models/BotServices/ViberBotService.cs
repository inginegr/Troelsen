using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;
using ServiceLibrary.Various;


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
        public bool ViberEntryPoint(int botNumber, Controller ctr, string commandToRun)
        {
            string ansMessage = string.Empty;
            try
            {
                string jsonString = ReadDataFromBrowser(ctr);

                Assembly vBot = Assembly.LoadFrom(PathToBotsLibrary(ctr));

                Type vBotType = vBot.GetType(entryPointClass);

                object vBotObject = Activator.CreateInstance(vBotType);

                int BotId = botNumber;
                string CommandToRun = commandToRun;
                string SecretKey = ctr.Request.Headers[viberAuth];
                string JsonFromServer = jsonString;
                string[] addsParams = new string[] { };

                ansMessage = (string)vBotType.InvokeMember(entryPointMethod, BindingFlags.InvokeMethod, null, vBotObject,
                    new object[] { BotId, CommandToRun, SecretKey, JsonFromServer, addsParams }, null);

                if (ansMessage == true.ToString())
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

        public string StartBot(int botNumber, Controller ctr)
        {
            try
            {
                string jsonString = ReadDataFromBrowser(ctr);

                Assembly vBot = LoadAssembly(PathToBotsLibrary(ctr));

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