using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Telegramm.Objects
{
    public class TgDocument
    {        
        public string file_id { get; set; }
        public string file_unique_id { get; set; }
        public TgPhotoSize thumb { get; set; }
        public string file_name { get; set; }
        public string mime_type { get; set; }
        public int file_size { get; set; } 
    }
}
