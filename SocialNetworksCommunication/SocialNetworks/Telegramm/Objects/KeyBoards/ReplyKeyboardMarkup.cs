using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class ReplyKeyboardMarkup 
    {
        public KeyboardButton[][] keyboard { get; set; }
        public bool resize_keyboard { get; set; }
        public bool one_time_keyboard { get; set; }
        public bool selective { get; set; }

        public ReplyKeyboardMarkup()
        {

        }
    }
}
