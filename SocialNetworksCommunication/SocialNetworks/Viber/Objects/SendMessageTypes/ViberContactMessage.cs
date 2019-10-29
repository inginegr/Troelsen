using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects.SendMessageTypes
{
    public class ViberContactMessage : ViberMessageBasic
    {
        public ViberContact Contact { get; set; }
    }
}