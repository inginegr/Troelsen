using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgInlineKeyboardButton
    {
        public string text { get; set; }
        public string url { get; set; }
        public string callback_data { get; set; }
        public string switch_inline_query { get; set; }
        public string switch_inline_query_current_chat { get; set; }
        public string callback_game { get; set; }
    }
}
