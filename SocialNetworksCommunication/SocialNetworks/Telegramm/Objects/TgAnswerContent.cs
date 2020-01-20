using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgAnswerContent
    {
        public string Text { get; set; }

        public override string ToString()
        {
            return $"Text -> {Text} \n\r";
        }
    }
}
