using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgMessageToSendWithReply : TgMessageToSend
    {
        public int reply_to_message_id { get; set; }
    }
}
