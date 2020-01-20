using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgChat
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string type { get; set; }

        public override string ToString()
        {
            return $"id -> {id};  first_name -> {first_name};  type -> {type}; \n\r";
        }
    }
}
