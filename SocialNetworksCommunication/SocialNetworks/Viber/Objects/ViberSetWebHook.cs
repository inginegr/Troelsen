using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects
{
    public class ViberSetWebHook
    {
        public string url { get; set; }
        public string[] event_types { get; set; }
        public bool send_name { get; set; }
        public bool send_photo { get; set; }

        public override string ToString()
        {
            string stypes = string.Empty;

            stypes = "[";
            foreach(string s in event_types)
            {
                stypes += $"{s} ,";
            }
            stypes += "]";

            return $"{{\n" +
                $"Url: {url} \n" +
                $"Event_types: {stypes},\n" +
                $"Send_name: {send_name}\n" +
                $"Send_photo: {send_photo}";
        }
    }
}
