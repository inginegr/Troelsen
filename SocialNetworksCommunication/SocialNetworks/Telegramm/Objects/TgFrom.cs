using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgFrom
    {
        public string id { get; set; }
        public string is_bot { get; set; }
        public string first_name { get; set; }
        public string language_code { get; set; }

        public override string ToString()
        {
            return $"id -> {id};  is_bot -> {is_bot};  first_name -> {first_name};  language_code -> {language_code} \n\r";
        }
    }
}
