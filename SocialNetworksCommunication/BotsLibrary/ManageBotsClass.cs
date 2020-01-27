using System;
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
using System.IO;

namespace ManageBotLibraries
{
    public class ManageBotsClass
    {
        private IBotsBaseClass BotsBase { get; set; }
        /// <summary>
        /// Basic name dependent on input request
        /// </summary>
        private string GetBaseName(BotTypes bots)
        {
            string retAns = string.Empty;            
            switch (bots)
            {
                case BotTypes.FbBot:
                    return BotNames.FaceBook;
                case BotTypes.TgBot:
                    return BotNames.Telegram;
                case BotTypes.ViberBot:
                    return BotNames.Viber;
                case BotTypes.VkBot:
                    return BotNames.VK;
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

                Assembly vBot = Assembly.LoadFrom(botParameters.PathToLibraries + className + ".dll");

                Type vBotType = vBot.GetType($"{className}.{className}");

                object vBotObject = Activator.CreateInstance(vBotType, botParameters.SecretKey);

                return (AnswerFromBot)vBotType.InvokeMember(nameof(BotsBase.EnterPoint), BindingFlags.InvokeMethod, null, vBotObject,
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