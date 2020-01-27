using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber
{
    public class ViberEvents
    {
        public const string WebHook = "webhook"; 
        public const string ConversationStarted = "conversation_started"; 
        public const string Delivered = "delivered"; 
        public const string Subscribed = "subscribed";
        public const string Unsubscribed = "unsubscribed"; 
        public const string Seen = "seen"; 
        public const string Failed = "failed"; 
        public const string Message = "message"; 
    }
}
