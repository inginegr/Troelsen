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



namespace BotsLibrary.ViberBots
{
    public class BasicViberClass
    {
        private class EventViber
        {
            public string Event { get; set; }
        }
        /// <summary>
        /// Service to communicate with viber server
        /// </summary>
        protected ViberComunicate viberService = new ViberComunicate();

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
        public AnswerFromBot ViberBotsStartPoint(BotParameters botParameters)
        {
            AnswerFromBot answer = new AnswerFromBot();
            try
            {
                EventViber viberEvent = null;
                if (botParameters.JsonFromServer != "" && botParameters.JsonFromServer != null)
                {
                    viberEvent = deserializeService.DeserializeToObjectT<EventViber>(botParameters.JsonFromServer);

                    // If event not null and empty then it is callback message
                    if (viberEvent.Event != null && viberEvent.Event != "")
                    {
                        switch (viberEvent.Event)
                        {
                            // Hello message
                            case "webhook":
                                return WebHookHandle(true);

                            case "conversation_started":
                                return ConversationStartedHandle(botParameters);

                            default:
                                answer.LogMessage = "CallBack command not found";
                                answer.IsTrue = false;
                                return answer;
                        }
                    }
                }
                else
                {
                    answer.IsTrue = false;
                    answer.LogMessage = "Server send empty message";
                }

                return answer;
            }
            catch (Exception ex)
            {
                answer.IsTrue = false;
                answer.LogMessage = $"Bot cannot call any function to handle command, because of error: {ex.Message}";
                return answer;
            }
        }

        /// <summary>
        /// Start Viber bot
        /// </summary>
        /// <param name="botParameters">Parameters to bot. AddsParameters[0] - address of entry point</param>
        /// <returns>AnswerFromBot class</returns>
        public AnswerFromBot StartBot(BotParameters botParameters)
        {
            AnswerFromBot answer = new AnswerFromBot();
            try
            {
                ViberSetWebHook webHook = (ViberSetWebHook)botParameters.AdditionObject;

                viberService.SetToken = botParameters.SecretKey;
                ResponseViberService responseViber = viberService.SetWebHook(webHook);

                answer.IsTrue = responseViber.IsTrue;
                answer.LogMessage = responseViber.LogData;

                return answer;

            }catch(Exception ex)
            {
                answer.LogMessage = ex.Message;
                answer.IsTrue = false;
                return answer;
            }
        }

        /// <summary>
        /// Handle of viber server webhook request
        /// </summary>
        /// <param name="IsReady">Fake parameter/ Set to true to start bot succesfully</param>
        /// <returns>AnswerFromBot class</returns>
        public AnswerFromBot WebHookHandle(bool IsReady)
        {
            AnswerFromBot retAns = new AnswerFromBot();
            try
            {
                if (IsReady)
                {
                    retAns.IsTrue = true;
                    retAns.LogMessage = "Bot is ready";
                }
                else
                {
                    retAns.IsTrue = false;
                    retAns.LogMessage = "Bot is not ready";
                }
                return retAns;
            }catch(Exception ex)
            {
                retAns.IsTrue = false;
                retAns.LogMessage = ex.Message;
                return retAns;
            }
        }

        public virtual AnswerFromBot ConversationStartedHandle(BotParameters botParameters)
        {
            return new AnswerFromBot();
        }

    }
}
