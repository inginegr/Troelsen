using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgUpdate
    {
        public string update_id { get; set; }
        public TgMessage message { get; set; }

        public override string ToString()
        {
            return $"update_id is: --> {update_id},  \n\r message:  -->  {message}";
        }
    }
}
