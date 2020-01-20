using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgChosenInlineResult
    {
        public string result_id { get; set; }

        public TgUser from { get; set; }

        public TgLocation location { get; set; }

        public string inline_message_id { get; set; }

        public string query { get; set; }
    }
}
