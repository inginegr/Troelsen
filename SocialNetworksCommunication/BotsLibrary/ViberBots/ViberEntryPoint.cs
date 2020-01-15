using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ServiceLibrary.Serialization;
using SocialNetworks.Viber.Objects;
using SocialNetworks.Viber.Comunicate;

namespace BotsLibrary.ViberBots
{
    public class ViberEntryPoint
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
        public string CallFunctions(int BotId, string CommandToRun, string SecretKey, string JsonFromServer, string[] addsParams=null)
        {
            try
            {   
                Type objWithMethods = Type.GetType($"{NameSpace}.{BaseBotName}{BotId}");
                object objectType = Activator.CreateInstance(objWithMethods);

                return objWithMethods.InvokeMember(CommandToRun, BindingFlags.InvokeMethod,
                    null, objectType, new object[] { addsParams, JsonFromServer }, null).ToString();
            } catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}