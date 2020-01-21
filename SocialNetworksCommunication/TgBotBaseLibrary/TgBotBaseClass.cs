using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotsBaseLibrary;
using SharedObjectsLibrary;
using SocialNetworks.Telegramm;
using SocialNetworks.Telegramm.Objects;
using ServiceLibrary.Serialization;
using ServiceLibrary.Various;


namespace TgBotBaseLibrary
{
    public class TgBotBaseClass
    {
        protected JsonSerializer serializer = new JsonSerializer();
        protected JsonDeserializer deserializer = new JsonDeserializer();
        protected TgCommunicate tg = new TgCommunicate();
        
        protected virtual string SecretKey { get => ""; }

        /// <summary>
        /// Entry point of all requests to bot
        /// </summary>
        /// <param name="botParameters">BotParameters class</param>
        /// <returns>AnswerFromBot class</returns>
        public AnswerFromBot EnterPointMethod(BotParameters botParameters)
        {
            AnswerFromBot botAns = new AnswerFromBot();
            try
            {
                if (botParameters?.SecretKey != SecretKey)
                {
                    botAns.IsTrue = false;
                    botAns.LogMessage = $"You have wrong secret key: {botParameters.SecretKey}";
                    return botAns;
                }else 
                //If it service command from local server or user
                if (botParameters?.ServiceCommands != TgServiceCommands.NoCommand)
                {
                    switch (botParameters.ServiceCommands)
                    {
                        case TgServiceCommands.StartBot:
                            return OnStartBot(botParameters);
                        case TgServiceCommands.StopBot:
                            return OnStopBot(botParameters);
                        default:
                            {
                                botAns.IsTrue = false;
                                botAns.LogMessage = $"There is no function to handle requested service command: {botParameters.ServiceCommands} ";
                                return botAns;
                            }
                    }
                }




                TgUpdate tgUp = deserializer.DeserializeToObjectT<TgUpdate>(botParameters.JsonFromServer);
                
                string textQuery = tgUp?.message?.text;
                                
                if (textQuery == null|| textQuery == "")
                {
                    throw new Exception("The textQuery command is empty. Cannot answer on empty request");
                }
                
                switch (textQuery)
                {
                    case "/start":
                        return OnStart(botParameters);

                    default:
                        {
                            AnswerFromBot ans = new AnswerFromBot();
                            ans.IsTrue = false;
                            ans.LogMessage = $"There are no method to handle event: -->{textQuery}";
                            return ans;
                        }
                }
            }
            catch(Exception ex)
            {
                botAns.IsTrue = false;
                botAns.LogMessage = $"There is error inside {nameof(TgBotBaseClass)} in {nameof(EnterPointMethod)}: {ex.Message}";
                return botAns;
            }
        }

        /// <summary>
        /// React on hello event
        /// </summary>
        /// <param name="bot"></param>
        /// <returns></returns>
        public virtual AnswerFromBot OnStart(BotParameters bot)
        {
            return new AnswerFromBot();
        }


        /// <summary>
        /// Service command to set webhooks of bot
        /// </summary>
        /// <param name="botParams">BotParameters class</param>
        /// <returns>Answer from tg server</returns>
        public virtual AnswerFromBot OnStartBot(BotParameters botParams)
        {
            AnswerFromBot fromBot = new AnswerFromBot();
            try
            {
                TgSetWebhookMessage tgSet = new TgSetWebhookMessage();
                tgSet.url = botParams.JsonFromServer;

                string reqString = serializer.SerializeObjectT(tgSet);
                string ans = tg.SetWebHook(reqString);

                fromBot.IsTrue = true;
                fromBot.LogMessage = ans;
                return fromBot;
            }catch(Exception ex)
            {
                fromBot.IsTrue = false;
                fromBot.LogMessage = ex.Message;
                return fromBot;
            }
        }

        /// <summary>
        /// Stop bot and clears all webhooks
        /// </summary>
        /// <param name="botParams">BotParameters class</param>
        /// <returns>Answer from tg server</returns>
        public virtual AnswerFromBot OnStopBot(BotParameters botParams)
        {
            AnswerFromBot answer = new AnswerFromBot();
            try
            {
                TgSetWebhookMessage tgSet = new TgSetWebhookMessage();
                tgSet.url = string.Empty;

                string reqString = serializer.SerializeObjectT(tgSet);
                string ans = tg.SetWebHook(reqString);

                answer.IsTrue = true;
                answer.LogMessage = ans;
                return answer;
            }
            catch(Exception ex)
            {
                answer.IsTrue = false;
                answer.LogMessage = $"The error occured inside OnStopBot method: {ex.Message}";
                return answer;
            }
        }
    }
}
