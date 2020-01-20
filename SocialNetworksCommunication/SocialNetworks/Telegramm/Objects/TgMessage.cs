
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

        public TgFrom from { get; set; }

        public TgChat chat { get; set; }

        public string date { get; set; }
        public string text { get; set; }

        public override string ToString()
        {
            return $"message_id -> {message_id}; date -> {date};  text -> {text} \n\r From -> {from.ToString()}  \n\r  Chat -> {chat.ToString()}";
        }
    }
}
