using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgForceReply
    {
        public bool force_reply { get => true; }
        public bool selective { get; set; }
    }
}
