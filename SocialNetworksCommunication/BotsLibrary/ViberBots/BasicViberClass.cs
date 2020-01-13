using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.Viber.Comunicate;
using SocialNetworks.Viber.Objects;
using ServiceLibrary.Serialization;
using BotsRestServices.Models.Objects.BotsLibRequest;


namespace BotsLibrary.ViberBots
{
    class BasicViberClass
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
        public BotsLibRequest ViberServiceStartPoint(BotsLibRequest request)
        {
            BotsLibRequest returnRequest = new BotsLibRequest();
            try
            {
                return returnRequest;
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
