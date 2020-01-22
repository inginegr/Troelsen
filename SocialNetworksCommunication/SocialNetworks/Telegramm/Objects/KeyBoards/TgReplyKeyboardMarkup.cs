using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgReplyKeyboardMarkup : TgMessageToSend
    {
        public ReplyKeyboardMarkup reply_markup { get; set; }

        public TgReplyKeyboardMarkup()
        {
            reply_markup = new ReplyKeyboardMarkup();
        }
    }
}
