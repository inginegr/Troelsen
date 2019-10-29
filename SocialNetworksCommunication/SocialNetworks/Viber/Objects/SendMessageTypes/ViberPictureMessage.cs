using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects.SendMessageTypes
{
    public class ViberPictureMessage : ViberMessageBasic
    {
        public string Text { get; set; }
        public string Media { get; set; }
        public string Thumbnail { get; set; }
    }
}
