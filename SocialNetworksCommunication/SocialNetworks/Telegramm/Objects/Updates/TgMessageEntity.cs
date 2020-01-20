using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgMessageEntity
    {
        public string type { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
        public string url { get; set; }
    }
}
