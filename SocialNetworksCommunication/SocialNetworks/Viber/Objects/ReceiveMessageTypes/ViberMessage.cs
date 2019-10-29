using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects.ReceiveMessageTypes
{
    public class ViberMessage
    {
        public string Type { get; set; }
        public string Text { get; set; }
        public string Media { get; set; }
        public ViberLocation Location { get; set; }
        public string Tracking_Data { get; set; }
    }
}
