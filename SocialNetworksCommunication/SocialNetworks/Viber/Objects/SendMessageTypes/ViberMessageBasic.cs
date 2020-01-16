using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects.SendMessageTypes
{
    public class ViberMessageBasic
    {        
        public ViberMessageSender sender { get; set; }
        public string tracking_data { get; set; }
        public string type { get; set; }
        public ViberMessageBasic()
        {
            sender = new ViberMessageSender();
        }
    }
}
