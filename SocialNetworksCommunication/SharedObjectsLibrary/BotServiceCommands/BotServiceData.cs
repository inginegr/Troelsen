using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjectsLibrary
{
    /// <summary>
    /// Data used to make service operations with bots: start stop and so on
    /// </summary>
    public class BotServiceData
    {
        //--------------------------- General service data--------------------------------------//
        public string url { get; set; }

        //----------------------------------------------------------------------------//

        //--------------------------- Service data to tg bots--------------------------------------//
        private int max_connections_local;
        public int max_connections
        {
            get => max_connections_local;
            set
            {
                if (value < 1)
                {
                    max_connections_local = 1;
                }
                else if (value > 100)
                {
                    max_connections_local = 100;
                }
                else
                {
                    max_connections_local = value;
                }
            }
        }
        public string[] allowed_updates { get; set; }
        //----------------------------------------------------------------------------//

/***************************************************************************************************************/

        //--------------------------- Service data to viber bots--------------------------------------//
        public string[] event_types { get; set; }
        public bool send_name { get; set; }
        public bool send_photo { get; set; }
        //----------------------------------------------------------------------------//
    }
}
