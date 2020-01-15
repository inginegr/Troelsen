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
        public string CommandToRun { get; set; }
        public string SecretKey { get; set; }
        public string JsonFromServer { get; set; }
        public BotObject[] BotParams { get; set; }
        public List<string> AdditionParameters { get; set; }
    }
}
