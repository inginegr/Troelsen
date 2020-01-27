using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedObjectsLibrary;
using SocialNetworks.Telegramm.Objects;
using TgBotBaseLibrary;
using BotsRestServices;

namespace TelegramBot1
{
    public class TelegramBot1 : TgCommands
    {
        //protected override string TokenKey => base.TokenKey;
        
        /// <summary>
        /// Makes repeated actions
        /// </summary>
        /// <typeparam name="T">Any type to send on tg server</typeparam>
        /// <param name="objectToSend"></param>
        /// <returns></returns>
        private AnswerFromBot CommonSendRequest<T>(T objectToSend)
        {
            AnswerFromBot answer = new AnswerFromBot() { IsTrue = false };
            try
            {
                string req = serializer.SerializeObjectT(objectToSend);
                string resp = tg.SendMessage(req, TokenKey);

                answer.LogMessage = resp;
                answer.IsTrue = true;
                return answer;
            }
            catch(Exception ex)
            {
                answer.LogMessage = $"Error occured inside CommonSendRequest method: --> {ex.Message}";
                return answer;
            }
        }

        /// <summary>
        /// Handle by messages from tg server
        /// </summary>
        /// <param name="botParameters">BotParameters class</param>
        /// <returns></returns>
        public override AnswerFromBot HandleTgServerRequests(BotParameters botParameters)
        {
            AnswerFromBot answer = new AnswerFromBot() { IsTrue = false };
            try
            {
                TgUpdate tgUp = deserializer.DeserializeToObjectT<TgUpdate>(botParameters.JsonFromServer);

                string textQuery = tgUp?.message?.text;

                if (textQuery == null || textQuery == "")
                {
                    throw new Exception("The textQuery command is empty. Cannot answer on empty request");
                }

                switch (textQuery)
                {
                    case StartCommand:
                        return OnStart(botParameters, tgUp);
                    case SayHelloCommand:
                        return OnSayHello(botParameters, tgUp);
                    case GetCurrentServerTimeCommand:
                        return OnGetCurrentTime(botParameters, tgUp);

                    default:
                        {
                            AnswerFromBot ans = new AnswerFromBot();
                            ans.IsTrue = false;
                            ans.LogMessage = $"There are no method to handle event: -->{textQuery}";
                            return ans;
                        }
                }
            }
            catch (Exception ex)
            {
                answer.LogMessage = $"Error occured inside HandleTgServerRequests messages: --> {ex.Message}";
                return answer;
            }
        }


        /// <summary>
        /// Gets current time on the server
        /// </summary>
        /// <param name="bot">BotParameters class</param>
        /// <param name="update">TgUpdate class</param>
        /// <returns>AnswerFromBot class</returns>
        private AnswerFromBot OnGetCurrentTime(BotParameters botParameters, TgUpdate tgUp)
        {
            AnswerFromBot answer = new AnswerFromBot() { IsTrue = false };
            try
            {
                TgMessageToSend tgMessage = new TgMessageToSend { chat_id = tgUp.message.chat.id };

                tgMessage.text = DateTime.Now.ToString("hh:mm:ss");

                return CommonSendRequest(tgMessage);
            }catch(Exception ex)
            {
                answer.LogMessage = ex.Message;
                return answer;
            }
        }

        /// <summary>
        /// Just sends Hello message to client
        /// </summary>
        /// <param name="bot">BotParameters class</param>
        /// <param name="update">TgUpdate class</param>
        /// <returns>AnswerFromBot class</returns>
        private AnswerFromBot OnSayHello(BotParameters botParameters, TgUpdate tgUp)
        {
            AnswerFromBot answer = new AnswerFromBot() { IsTrue = false };
            try
            {
                TgMessageToSend tgMessage = new TgMessageToSend { parse_mode = "MarkdownV2", chat_id = tgUp.message.chat.id };
                tgMessage.text = $"Hello *{tgUp.message.from.first_name}*";

                return CommonSendRequest(tgMessage);
            }
            catch (Exception ex)
            {
                answer.LogMessage = ex.Message;
                return answer;
            }
        }


        /// <summary>
        /// Handle start command 
        /// </summary>
        /// <param name="bot">BotParameters class</param>
        /// <param name="update">TgUpdate class</param>
        /// <returns>AnswerFromBot class</returns>
        public AnswerFromBot OnStart(BotParameters bot, TgUpdate update)
        {
            string s = string.Empty;
            AnswerFromBot answer = new AnswerFromBot();
            try
            {
                TgReplyKeyboardMarkup tgMessage = new TgReplyKeyboardMarkup() { parse_mode = "MarkdownV2", chat_id = update.message.chat.id };

                tgMessage.text = $"Привет *{update.message.from.first_name}*\n Чего ты хочешь?";

                KeyboardButton[][] buttons = new KeyboardButton[2][];
                buttons[0] = new KeyboardButton[1] { new KeyboardButton { text=SayHelloCommand } };
                buttons[1] = new KeyboardButton[1] { new KeyboardButton { text = GetCurrentServerTimeCommand } };

                tgMessage.reply_markup.keyboard = buttons;

                return CommonSendRequest(tgMessage);
            }catch(Exception ex)
            {
                answer.IsTrue = false;
                answer.LogMessage = $"The error occured inside OnHello method:  {ex.Message}{s}";
                return answer;
            }
        }

        public TelegramBot1()
        {
            throw new Exception("Please set token key, in TelegramBot1 constructor ");
        }

        public TelegramBot1(string token):base(token)
        {
        }
    }    
}
