using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.Viber.Objects;
using SocialNetworks.Viber.Comunicate;


namespace BotsLibrary.ViberBots
{
    /// <summary>
    /// Test viber bot
    /// </summary>
    public class ViberBot1 : BasicViberClass, IViberBot
    {
        /// <summary>
        /// Start function of viber bot. When message come from viber server, this fuction called first of all
        /// </summary>
        /// <param name="jsonString">Json string from server</param>
        public string ViberBotsStartPoint(string[] addsParam, string jsonFromServer)
        {
            try
            {
                ViberHelloMessage viberHello = null;
                if(jsonFromServer!="" && jsonFromServer != null)
                {
                    viberHello = deserializeService.DeserializeToObjectT<ViberHelloMessage>(jsonFromServer);

                    // If event not null and empty then it is callback message
                    if (viberHello.Event != null && viberHello.Event != "")
                    {
                        switch (viberHello.Event)
                        {
                            // Hello message
                            case "webhook":
                                return true.ToString();
                                case "conversation_started"
                        }
                    }
                }

                return true.ToString();
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
