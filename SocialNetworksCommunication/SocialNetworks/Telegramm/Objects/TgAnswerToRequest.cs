using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgAnswerToRequest
    {
        public TgAnswerContent Result { get; set; }

        public override string ToString()
        {
            return $"Result -> {Result.ToString()} \n\r";
        }
    }
}
