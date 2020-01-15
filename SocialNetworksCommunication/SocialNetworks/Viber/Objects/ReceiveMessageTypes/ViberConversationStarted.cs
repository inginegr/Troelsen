using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects.ReceiveMessageTypes
{
    /// <summary>
    /// Comes to bot, when user open dialog
    /// </summary>
    public class ViberConversationStarted
    {
        public string Event { get; set; }
        public string TimeStamp { get; set; }
        public string Message_Token { get; set; }
        public string Type { get; set; }
        public string Context { get; set; }
        public ViberSender User { get; set; }
        public bool Subscribed { get; set; }
    }
}