using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.Viber.Objects;
using SocialNetworks.Viber.Comunicate;
using SharedObjectsLibrary;
using SocialNetworks.Viber;
using SocialNetworks.Viber.Objects.ReceiveMessageTypes;
using SocialNetworks.Viber.Objects.SendMessageTypes;

namespace BotsLibrary.ViberBots
{
    /// <summary>
    /// Test viber bot
    /// </summary>
    public class ViberBot1 : BasicViberClass
    {
        public override AnswerFromBot ConversationStartedHandle(BotParameters botParameters)
        {
            AnswerFromBot ans = new AnswerFromBot();
            try
            {
                ViberConversationStarted conversationStartedObject = deserializeService.DeserializeToObjectT<ViberConversationStarted>(botParameters.JsonFromServer);

                ViberTextMessage textMessage = new ViberTextMessage();
                textMessage.Receiver = conversationStartedObject.User.Id;
                textMessage.Text = "Hello man";
                
                ResponseViberService resp =  viberService.SendTextMessageToBot(textMessage);
                
                ans.IsTrue = resp.IsTrue;
                ans.LogMessage = resp.LogData;

                return ans;
            }catch(Exception ex)
            {
                ans.IsTrue = false;
                ans.LogMessage = ex.Message;
                return ans;
            }
        }
    }
}
