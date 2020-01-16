using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects
{
    public class ViberSetWebHook
    {
        public string Url { get; set; }
        public string[] Event_types { get; set; }
        public bool Send_name { get; set; }
        public bool Send_photo { get; set; }

        public override string ToString()
        {
            string stypes = string.Empty;

            stypes = "[";
            foreach(string s in Event_types)
            {
                stypes += $"{s} ,";
            }
            stypes += "]";

            return $"{{\n" +
                $"Url: {Url} \n" +
                $"Event_types: {stypes},\n" +
                $"Send_name: {Send_name}\n" +
                $"Send_photo: {Send_photo}";
        }
    }
}
