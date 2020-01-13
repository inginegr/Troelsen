using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using BotsRestServices.Models.Objects.BotsLibRequest;
using ServiceLibrary.Serialization;
using SocialNetworks.Viber.Objects;

namespace ViberBots
{
    public class ViberEntryPoint
    {
        /// <summary>
        /// Deserialize object
        /// </summary>
        JsonDeserializer deserializer = new JsonDeserializer();

        /// <summary>
        /// Name space, that contain all viber bots
        /// </summary>
        private string NameSpace { get => nameof(ViberBots); }

        /// <summary>
        /// Basic bot name, that contained in all bots
        /// </summary>
        private string BaseBotName { get => "ViberBot"; }

        /// <summary>
        /// Call 
        /// </summary>
        /// <param name="botNumber">Number of bot, that created</param>
        /// <param name="jsonString">String, send by viber server</param>
        public void CallFunctions(BotsLibRequest request)
        {
            BotsLibRequest returnRequest = new BotsLibRequest();
            try
            {
                ViberHelloMessage helloMessage = deserializer.DeserializeToObjectT<ViberHelloMessage>(request.JsonFromServer);
                Type objWithMethods = Type.GetType($"{NameSpace}.{BaseBotName}{request.BotId}");
                object objectType = Activator.CreateInstance(objWithMethods);

                objWithMethods.InvokeMember(request.CommandToRun, BindingFlags.InvokeMethod, null, objectType, new object[] { request }, null);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}