using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.Viber.Comunicate;
using SocialNetworks.Viber.Objects;
using SocialNetworks.Viber;
using ServiceLibrary.Serialization;
using SharedObjectsLibrary;
using BotsBaseLibrary;


namespace ViberBotBaseLibrary
{
    public class ViberBotBaseClass :BotsBaseClass, IBotsBaseClass
    {
        private class EventViber
        {
            public string Event { get; set; }
        }
        /// <summary>
        /// Service to communicate with viber server
        /// </summary>
        protected ViberComunicate viberService = null;

        /// <summary>
        /// Serialize service
        /// </summary>
        protected JsonSerializer serializeService = new JsonSerializer();

        /// <summary>
        /// Deserializer
        /// </summary>
        protected JsonDeserializer deserializeService = new JsonDeserializer();

        /// <summary>
        /// Start function of viber bot. When message come from viber server, this fuction called first of all
        /// </summary>
        /// <param name="jsonString">Json string from server</param>
        public AnswerFromBot EnterPoint(BotParameters botParameters)
        {
            AnswerFromBot botAns = new AnswerFromBot();
            try
            {
                if (botParameters?.SecretKey != TokenKey)
                {
                    botAns.IsTrue = false;
                    botAns.LogMessage = $"You have wrong secret key: {botParameters.SecretKey}";
                    return botAns;
                }
                else
                //If it service command from local server or user
                if (botParameters?.ServiceCommands != TgServiceCommands.NoCommand)
                {
                    return HandleServiceRequests(botParameters);
                }
                else
                // If message from viber server
                if (botParameters.JsonFromServer != string.Empty)
                {
                    return HandleViberServerRequests(botParameters);
                }
                else
                {
                    botAns.LogMessage = $"Cannot handle empty request inside EnterPointMethod ";
                    return botAns;
                }
            }
            catch (Exception ex)
            {
                botAns.IsTrue = false;
                botAns.LogMessage = $"There is error inside {nameof(ViberBotBaseClass)} in {nameof(EnterPoint)}: {ex.Message}";
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
            catch (Exception ex)
            {
                answer.LogMessage = $"Error occured inside HandleServiceRequests method: -->{ex.Message}";
                return answer;
            }
        }

        /// <summary>
        /// Handle by webhook callback from viber server
        /// </summary>
        /// <returns></returns>
        private AnswerFromBot OnWebHook()
        {
            AnswerFromBot botAnswer = new AnswerFromBot();
            try
            {
                botAnswer.IsTrue = true;
                botAnswer.LogMessage = "ok";
                return botAnswer;
            }catch(Exception ex)
            {
                botAnswer.IsTrue = false;
                botAnswer.LogMessage = $"Bot does not started: --> {ex.Message} ";
                return botAnswer;
            }
        }

        
        /// <summary>
        /// Service command to set webhooks of bot
        /// </summary>
        /// <param name="botParams">BotParameters class</param>
        /// <returns>Answer from tg server</returns>
        protected virtual AnswerFromBot OnStartBot(BotParameters botParams)
        {
            AnswerFromBot botAnswer = new AnswerFromBot();
            try
            {
                BotServiceData serviceData = deserializer.DeserializeToObjectT<BotServiceData>(botParams.JsonFromServer);
                ViberSetWebHook viberSetWebHook = new ViberSetWebHook();
                viberSetWebHook.url = $"https://{serviceData.url}{UrlPostfixToReceiveRequestsFromBot.ViberPostfix}{botParams.BotId}/{TokenKey}";
                viberSetWebHook.send_photo = serviceData.send_photo;
                viberSetWebHook.send_name = serviceData.send_name;
                viberSetWebHook.event_types = serviceData.event_types;

                ResponseViberService response = viberService.SetWebHook(viberSetWebHook);

                if (response.IsTrue)
                {
                    botAnswer.IsTrue = true;
                    botAnswer.LogMessage = "Bot started succesfully";
                }
                else
                {
                    botAnswer.IsTrue = false;
                    botAnswer.LogMessage = $"Error responsed from viber server, while setting webhook: --> {response.LogData}";
                }

                return botAnswer;
            }
            catch (Exception ex)
            {
                botAnswer.IsTrue = false;
                botAnswer.LogMessage = ex.Message;
                return botAnswer;
            }
        }

        
        /// <summary>
        /// Stop bot and clears all webhooks
        /// </summary>
        /// <param name="botParams">BotParameters class</param>
        /// <returns>Answer from tg server</returns>
        protected virtual AnswerFromBot OnStopBot(BotParameters botParams)
        {
            AnswerFromBot botAns = new AnswerFromBot();
            try
            {
                ViberSetWebHook viberSetWebHook = new ViberSetWebHook();
                viberSetWebHook.url = "";
                ResponseViberService resp = viberService.SetWebHook(viberSetWebHook);

                if (resp.IsTrue)
                {
                    botAns.IsTrue = true;
                    botAns.LogMessage = "Webhooks succesfully deleted";
                }
                else
                {
                    botAns.IsTrue = false;
                    botAns.LogMessage = resp.LogData;
                }

                return botAns;
            }
            catch (Exception ex)
            {
                botAns.IsTrue = false;
                botAns.LogMessage = $"The error occured inside OnStopBot method: {ex.Message}";
                return botAns;
            }
        }

        /// <summary>
        /// Handle by messages from tg server
        /// </summary>
        /// <param name="botParameters">BotParameters class</param>
        /// <returns></returns>
        private AnswerFromBot HandleViberServerRequests(BotParameters botParameters)
        {
            AnswerFromBot botAnswer = new AnswerFromBot();
            try
            {
                EventViber eventViber = deserializer.DeserializeToObjectT<EventViber>(botParameters.JsonFromServer);
                switch (eventViber.Event)
                {
                    case ViberEvents.WebHook:
                        return OnWebHook();

                    default:
                        botAnswer.IsTrue = false;
                        botAnswer.LogMessage = "There are no method to handle request from viber server";
                        return botAnswer;
                }
            }
            catch (Exception ex)
            {
                botAnswer.IsTrue = false;
                botAnswer.LogMessage = $"The error occured while try to handle request from viber server: --> {ex.Message}";
                return botAnswer;
            }
        }

        public virtual AnswerFromBot ConversationStartedHandle(BotParameters botParameters)
        {
            return new AnswerFromBot();
        }

        public ViberBotBaseClass() { }

        public ViberBotBaseClass(string token):base(token)
        {
            viberService = new ViberComunicate(token);
        }
    }
}
