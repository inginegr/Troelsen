using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgMessage
    {
        public string message_id { get; set; }

        public TgUser from { get; set; }

        public int date { get; set; }

        public TgChat chat { get; set; }

        public TgUser forard_from { get; set; }

        public int forward_date { get; set; }

        public TgMessage reply_to_message { get; set; }

        public string text { get; set; }

        public TgMessageEntity[] entities { get; set; }

        public TgAudio audio { get; set; }

        public override string ToString()
        {
            return $"message_id -> {message_id}; date -> {date};  text -> {text} \n\r From -> {from.ToString()}  \n\r  Chat -> {chat.ToString()}";
        }
    }
}
