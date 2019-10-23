using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects
{
    public class ViberCallBackData
    {
        public ViberWebhookResponse Webhook { get; set; }

        public string Timestamp { get; set; }

        public string Message_token { get; set; }

        public override string ToString()
        {
            return $"WebHooks -> {Webhook.ToString()} TimeStamp -> {Timestamp} Message Token -> {Message_token}";
        }
    }
}
