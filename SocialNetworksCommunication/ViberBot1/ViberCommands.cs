using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViberBot1
{
    public class ViberCommands : ViberBotBaseLibrary.ViberBotBaseClass
    {
        protected const string StartCommand = "/start";
        protected const string SayHelloCommand = "Сказать привет";
        protected const string GetCurrentServerTimeCommand = "Получить время на сервере";

        public ViberCommands() { }

        public ViberCommands(string token) : base(token) { }
    }
}
