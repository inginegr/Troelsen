﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ServiceLibrary.Serialization;
using SocialNetworks.Viber.Objects;
using SocialNetworks.Viber.Comunicate;
using SharedObjectsLibrary;
using BotsBaseLibrary;



namespace ManageBotLibraries
{
    public class ManageBotsClass
    {
        /// <summary>
        /// Basic name dependent on input request
        /// </summary>
        private string GetBaseName(BotTypes bots)
        {
            string retAns = string.Empty;
            switch (bots)
            {
                case BotTypes.FbBot:
                    return "FaceBook";
                case BotTypes.TgBot:
                    return "Telegram";
                case BotTypes.ViberBot:
                    return "Viber";
                case BotTypes.VkBot:
                    return "VK";
                default:
                    return string.Empty;
            }
        }
        
        /// <summary>
        /// Get name of library to load
        /// </summary>
        /// <param name="bots">enum of bots</param>
        /// <param name="botNumber">number of bot</param>
        /// <returns>name of library to load</returns>
        private string GetClassName(BotTypes bots, int botNumber)
        {
            return $"{GetBaseName(bots)}Bot{botNumber}";
        } 

        /// <summary>
        /// Basic bot name, that contained in all bots
        /// </summary>
        //private string BaseBotName { get => "ViberBot"; }

        /// <summary>
        /// Call 
        /// </summary>
        /// <param name="botNumber">Number of bot, that created</param>
        /// <param name="jsonString">String, send by viber server</param>
        public AnswerFromBot CallFunctions(BotParameters botParameters)
        {
            AnswerFromBot ansMessage = null;
            try
            {
                string className = GetClassName(botParameters.BotType, botParameters.BotId);

                Assembly vBot = Assembly.LoadFrom(className);

                Type vBotType = vBot.GetType($"{className}.{className}");

                object vBotObject = Activator.CreateInstance(vBotType);

                return (AnswerFromBot)vBotType.InvokeMember("EnterPointMethod", BindingFlags.InvokeMethod, null, vBotObject,
                    new object[] { botParameters }, null);
            }
            catch (Exception ex)
            {
                ansMessage.LogMessage = ex.Message;
                ansMessage.IsTrue = false;
                return ansMessage;
            }
        }
    }
}