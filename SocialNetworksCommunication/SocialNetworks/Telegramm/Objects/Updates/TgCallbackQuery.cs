using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgCallbackQuery
    {
        public string id { get; set; }

        public TgUser from { get; set; }

        public TgMessage message { get; set; }

        public string inline_message_id { get; set; }

        public string data { get; set; }
    }
}
