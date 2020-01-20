using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgMessageToSend
    {
        public string chat_id { get; set; }
        public string text { get; set; }
        public string parse_mode { get; set; }
        public bool disable_web_page_preview { get; set; }
        public bool disable_notification { get; set; }
        public int reply_to_message_id { get; set; }
    }
}
