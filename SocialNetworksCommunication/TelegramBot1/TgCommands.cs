using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TgBotBaseLibrary;

namespace TelegramBot1
{
    public class TgCommands : TgBotBaseClass
    {
        protected const string StartCommand = "/start";
        protected const string SayHelloCommand = "Сказать привет";
        protected const string GetCurrentServerTimeCommand = "Получить время на сервере";

        public TgCommands()
        {

        }

        public TgCommands(string token) : base(token)
        {

        }
    }
}
