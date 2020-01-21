using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjectsLibrary
{
    
    public class BotParameters
    {
        public int BotId { get; set; }       
        public string SecretKey { get; set; }
        public string JsonFromServer { get; set; }
        public BotObject[] BotObjects { get; set; }
        public List<string> AdditionParameters { get; set; }
        public object AdditionObject { get; set; }
        public BotTypes BotType { get; set; }
        public TgServiceCommands ServiceCommands { get; set; }
        public string PathToLibraries { get; set; }
    }
}
