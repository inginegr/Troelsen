using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects
{
    public class ViberWebhookResponse
    {
        public int Status { get; set; }

        public string Status_message { get; set; }

        public string[] Event_types { get; set; }

        public override string ToString()
        {
            string mas = String.Empty;
            foreach(string s in Event_types)
            {
                mas += $"Event type -> {Event_types}  ";
            }

            return $"Status -> {Status} \n Status Message -> {Status_message} \n Subscribed to events type -> {mas} \n\r";
        }
    }
}