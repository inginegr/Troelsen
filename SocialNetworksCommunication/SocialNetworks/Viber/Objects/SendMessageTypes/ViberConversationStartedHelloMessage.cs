using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects.SendMessageTypes
{
    public class ViberConversationStartedHelloMessage : ViberMessageBasic
    {
        public string text { get; set; }
        public string media { get; set; }
        public string thumbnail { get; set; }
    }
}
