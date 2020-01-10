using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;

namespace BotsRestServices.Models.BotServices
{
    public class ViberBotService : BaseBotService
    {
        private string entryPointClass = "ViberBots.ViberEntryPoint";
        private string entryPointMethod = "CallFunctions";


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
                
                entryMethod.Invoke(vBotObject, new object[] { botNumber, jsonString, new string[] { "" } } );

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