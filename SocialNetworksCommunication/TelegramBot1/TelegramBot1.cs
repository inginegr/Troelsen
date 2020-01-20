using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedObjectsLibrary;
using TgBotBaseLibrary;

namespace TelegramBot1
{
    public class TelegramBot1 : TgBotBaseClass
    {
        public override AnswerFromBot OnHello(BotParameters bot)
        {
            AnswerFromBot answer = new AnswerFromBot();
            try
            {

                return answer;
            }catch(Exception ex)
            {
                answer.IsTrue = false;
                answer.LogMessage = $"The error occured inside OnHello method:  {ex.Message}";
                return answer;
            }
        }
    }
}
