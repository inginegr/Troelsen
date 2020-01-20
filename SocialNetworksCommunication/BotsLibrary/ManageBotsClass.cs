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


namespace ManageBotLibraries
{
    public class ManageBotsClass
    {
        /// <summary>
        /// Name space, that contain all viber bots
        /// </summary>
        private string NameSpace { get => "BotsLibrary.ViberBots"; }

        /// <summary>
        /// Basic bot name, that contained in all bots
        /// </summary>
        private string BaseBotName { get => "ViberBot"; }

        /// <summary>
        /// Call 
        /// </summary>
        /// <param name="botNumber">Number of bot, that created</param>
        /// <param name="jsonString">String, send by viber server</param>
        public AnswerFromBot CallFunctions(BotParameters botParameters)
        {
            AnswerFromBot answer = new AnswerFromBot();
            try
            {   
                Type objWithMethods = Type.GetType($"{NameSpace}.{BaseBotName}{botParameters.BotId}");
                object objectType = Activator.CreateInstance(objWithMethods);

                return (AnswerFromBot)objWithMethods.InvokeMember(botParameters.CommandToRun, BindingFlags.InvokeMethod,
                    null, objectType, new object[] { botParameters }, null);
            } catch(Exception ex)
            {
                answer.LogMessage = ex.Message;
                return answer;
            }
        }
    }
}