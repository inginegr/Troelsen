using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber
{
    public class Events
    {
        public string WebHook { get => "webhook"; }
        public string ConversationStarted { get => "conversation_started"; }
        public string Delivered { get => "delivered"; }
        public string Subscribed { get => "subscribed"; }
        public string Unsubscribed { get => "unsubscribed"; }
        public string Seen { get => "seen"; }
        public string Failed { get => "failed"; }
        public string Message { get => "message"; }

    }
}
