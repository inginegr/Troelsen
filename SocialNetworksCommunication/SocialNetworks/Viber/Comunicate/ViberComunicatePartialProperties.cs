using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.Services;
using ServiceLibrary.Serialization;
using ServiceLibrary.Various;

namespace SocialNetworks.Viber.Comunicate
{
    public partial class ViberComunicate
    {
        /*------------------------------ Services----------------------------------*/
        InternetService _internet = new InternetService();

        JsonSerializer _serializer = new JsonSerializer();

        JsonDeserializer _deserializer = new JsonDeserializer();

        //Basic url string
        private string commonReqString = @"https://chatapi.viber.com/pa/";

        // Send message path segment
        private string resourceUrl = @"send_message";

        // Set webhook path segment
        private string settingWebHook = @"set_webhook";

        // Header key viber message
        private string viberHeaderKey = "X-Viber-Auth-Token";
        
        // Header value viber message
        private string viberHeaderValue = string.Empty;
        public string SetToken { set { viberHeaderValue = value; } }

    }
}
