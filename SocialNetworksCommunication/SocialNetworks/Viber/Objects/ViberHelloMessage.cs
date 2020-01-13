using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects
{
    /// <summary>
    /// Hello message from viber server, when set webhooks of bot
    /// </summary>
    public class ViberHelloMessage
    {
        public string Event { get; set; }
        public string TimeStamp { get; set; }
        public string Chat_HostName { get; set; }
        public string Message_Token { get; set; }
    }
}