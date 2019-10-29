using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects.SendMessageTypes
{
    public class ViberFileMessage : ViberMessageBasic
    {
        public string Media { get; set; }
        public string Size { get; set; }
        public string File_name { get; set; }
    }
}