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
                    if(viberHello.Event != null && viberHello.Event != "")
                    {
                        if(viberHello.Event== "webhook")
                        {
                            return true.ToString();
                        }
                        else
                        {
                            return false.ToString();
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
