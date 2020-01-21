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

        public TgChat forward_from_chat { get; set; }

        public int forward_from_message_id { get; set; }

        public string forward_signature { get; set; }

        public string forward_sender_name { get; set; }

        public int forward_date { get; set; }

        public TgMessage reply_to_message { get; set; }

        public int edit_date { get; set; }

        public string media_group_id { get; set; }

        public string author_signature { get; set; }

        public string text { get; set; }

        public TgMessageEntity[] entities { get; set; }

        public TgMessageEntity[] caption_entities { get; set; }

        public TgAudio audio { get; set; }

        public TgDocument document { get; set; }

        public override string ToString()
        {
            return $"message_id -> {message_id}; date -> {date};  text -> {text} \n\r From -> {from.ToString()}  \n\r  Chat -> {chat.ToString()}";
        }
    }
}
