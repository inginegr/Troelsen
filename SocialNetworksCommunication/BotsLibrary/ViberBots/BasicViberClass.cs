using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.Viber.Comunicate;
using SocialNetworks.Viber.Objects;
using ServiceLibrary.Serialization;


namespace BotsLibrary.ViberBots
{
    public class BasicViberClass
    {
        /// <summary>
        /// Service to communicate with viber server
        /// </summary>
        protected ViberComunicate viberService = new ViberComunicate();

        /// <summary>
        /// Serialize service
        /// </summary>
        protected JsonSerializer serializeService = new JsonSerializer();

        /// <summary>
        /// Deserializer
        /// </summary>
        protected JsonDeserializer deserializeService = new JsonDeserializer();

        /// <summary>
        /// Startviber bot function
        /// </summary>
        /// <param name="stringParam">Parameters, that passed to bot</param>
        public void ViberServiceStartPoint()
        {
            try
            {
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //public BotsLibRequest StartBot(BotsLibRequest request)
        //{
        //    BotsLibRequest returnRequest = new BotsLibRequest();
        //    try
        //    {
                
        //        retu
        //    }catch(Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
