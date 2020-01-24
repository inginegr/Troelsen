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
        
        protected virtual string TokenKey { get; set; }

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
                if (botParameters?.SecretKey != TokenKey)
                {
                    botAns.IsTrue = false;
                    botAns.LogMessage = $"You have wrong secret key: {botParameters.SecretKey}";
                    return botAns;
                }else 
                //If it service command from local server or user
                if (botParameters?.ServiceCommands != TgServiceCommands.NoCommand)
                {
                    return HandleServiceRequests(botParameters);
                }else
                // If message from viber server
                if (botParameters.JsonFromServer != string.Empty) 
                {
                    return HandleTgServerRequests(botParameters);
                }
                else
                {
                    botAns.LogMessage = $"Cannot handle empty request inside EnterPointMethod ";
                    return botAns;
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
        /// Handle service requests
        /// </summary>
        /// <param name="botParameters"> BotParameters class</param>
        /// <returns></returns>
        private AnswerFromBot HandleServiceRequests(BotParameters botParameters)
        {
            AnswerFromBot answer = new AnswerFromBot() { IsTrue = false };
            try
            {
                switch (botParameters.ServiceCommands)
                {
                    case TgServiceCommands.StartBot:
                        return OnStartBot(botParameters);
                    case TgServiceCommands.StopBot:
                        return OnStopBot(botParameters);
                    default:
                        {
                            answer.IsTrue = false;
                            answer.LogMessage = $"There is no function to handle requested service command: {botParameters.ServiceCommands} ";
                            return answer;
                        }
                }
            }
            catch(Exception ex)
            {
                answer.LogMessage = $"Error occured inside HandleServiceRequests method: -->{ex.Message}";
                return answer;
            }
        }

        /// <summary>
        /// Handle by messages from tg server
        /// </summary>
        /// <param name="botParameters">BotParameters class</param>
        /// <returns></returns>
        public virtual AnswerFromBot HandleTgServerRequests(BotParameters botParameters)
        {
            AnswerFromBot answer = new AnswerFromBot() { IsTrue = false };
            return answer;
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
                BotServiceData serviceData = deserializer.DeserializeToObjectT<BotServiceData>(botParams.JsonFromServer);

                TgSetWebhookMessage tgSet = new TgSetWebhookMessage();
                tgSet.url = $"https://{serviceData.url}{UrlPostfixToReceiveRequestsFromBot.TgPostfix}{botParams.BotId}/{TokenKey}";
                tgSet.allowed_updates = serviceData.allowed_updates;
                tgSet.max_connections = serviceData.max_connections;
                
                string reqString = serializer.SerializeObjectT(tgSet);
                string ans = tg.SetWebHook(reqString, TokenKey);

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
                string ans = tg.SetWebHook(reqString, TokenKey);

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

        public TgBotBaseClass()
        {

        }

        public TgBotBaseClass(string token)
        {
            TokenKey = token;
        }
    }
}
