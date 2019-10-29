using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects.SendMessageTypes
{
    public class ViberMessageBasic
    {
        public string Receiver { get; set; }
        public string Min_api_version { get; set; }
        public ViberMessageSender Sender { get; set; }
        public string Tracking_data { get; set; }
        public string Type { get; set; }
    }
}
