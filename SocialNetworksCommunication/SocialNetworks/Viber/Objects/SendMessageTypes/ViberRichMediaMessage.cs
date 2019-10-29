using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects.SendMessageTypes
{
    public class ViberRichMediaMessage
    {
        public string Receiver { get; set; }
        public string Type { get; set; }
        public string Min_Api_Version { get; set; }
        public ViberRichMedia Rich_Media { get; set; }
    }
}