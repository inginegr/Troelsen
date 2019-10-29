using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects.ReceiveMessageTypes
{
    public class ViberReceiveMessageFromUser
    {
        public string Event { get; set; }
        public string Timestamp { get; set; }
        public string Message_Token { get; set; }
        public ViberSender Sender { get; set; }
        public ViberMessage Message { get; set; }
        public string Tracking_Data { get; set; }
    }
}