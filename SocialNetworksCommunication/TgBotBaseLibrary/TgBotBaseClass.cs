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
                TgUpdate tgUp = deserializer.DeserializeToObjectT<TgUpdate>(botParameters.JsonFromServer);


                string textQuery = tgUp.message.text;
                switch (textQuery)
                {
                    case "hello":
                        return OnHello(botParameters);

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
                botAns.LogMessage = $"There is error inside EnterPointMethod: {ex.Message}";
                return botAns;
            }
        }

        /// <summary>
        /// React on hello event
        /// </summary>
        /// <param name="bot"></param>
        /// <returns></returns>
        public virtual AnswerFromBot OnHello(BotParameters bot)
        {
            return new AnswerFromBot();
        }
    }
}
