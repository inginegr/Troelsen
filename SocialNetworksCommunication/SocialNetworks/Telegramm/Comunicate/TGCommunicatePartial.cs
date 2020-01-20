using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialNetworks.Services;
using ServiceLibrary.Serialization;
using SocialNetworks.Telegramm.Objects;
using ServiceLibrary.Various;
using SocialNetworks.Telegramm.Objects;

namespace SocialNetworks.Telegramm
{
    /// <summary>
    /// Properties and constants
    /// </summary>
    public partial class TgCommunicate
    {
        //Deserializator of json string
        private JsonDeserializer jso = new JsonDeserializer();
               
        //Crypto service to operate by secret key
        KeysTGHandle keysHandle = null;

        //To send commands using interent
        InternetService inetService = new InternetService();

        // Secret key to communicate with telegram server
        private string Token { get => keysHandle.GetSecretKey(); }

        //Base string to communicate with bot
        private string BaseQeruestString = "https://api.telegram.org/bot";
    }
}
