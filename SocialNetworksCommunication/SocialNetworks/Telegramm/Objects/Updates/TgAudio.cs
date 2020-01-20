using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgAudio
    {
        public string file_id { get; set; }
        public int duration { get; set; }
        public string performer { get; set; }
        public string title { get; set; }
        public string mime_type { get; set; }
        public int file_size { get; set; }
    }
}
