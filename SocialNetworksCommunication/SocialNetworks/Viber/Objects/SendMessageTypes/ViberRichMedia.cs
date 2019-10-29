using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects.SendMessageTypes
{
    public class ViberRichMedia
    {
        public string Type { get; set; }
        public string ButtonsGroupColumns { get; set; }
        public string ButtonsGroupRows { get; set; }
        public string BgColor { get; set; }
        public ViberButtons[] Buttons { get; set; }
    }
}