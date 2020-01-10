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
        /// Startviber bot function
        /// </summary>
        /// <param name="stringParam">Parameters, that passed to bot</param>
        void ViberServiceStartPoint(string stringParam, string[] param)
        {
            try
            {
                if (stringParam == "StartBot")
                {

                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private void StartBot(string[] param)
        {
            try
            {
                viberService.SetToken = param[0];
               // viberService.StartListen()
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
