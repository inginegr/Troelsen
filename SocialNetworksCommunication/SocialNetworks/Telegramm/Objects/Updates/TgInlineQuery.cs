using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgInlineQuery
    {
        public string id { get; set; }

        public TgUser from { get; set; }

        public TgLocation location { get; set; }

        public string query { get; set; }

        public string offset { get; set; }
    }
}
