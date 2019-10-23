using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects
{
    public class ViberReceiveMessageFromUser
    {
        public string Event { get; set; }
        public string Timestamp { get; set; }
        public string Chat_hostname { get; set; }
        public string Message_token { get; set; }
        public ViberSender Sender { get; set; }
        public ViberMessage Message { get; set; }
        public string Silent { get; set; }
    }
}