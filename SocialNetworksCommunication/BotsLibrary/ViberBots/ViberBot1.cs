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

                ViberConversationStartedHelloMessage textMessage = new ViberConversationStartedHelloMessage();
                textMessage.media = "";
                textMessage.sender.avatar = "";
                textMessage.sender.name = "";
                textMessage.thumbnail = "";
                textMessage.tracking_data = "";
                textMessage.type = "text";
                textMessage.text = "Hello man";

                ans.IsTrue = true;
                ans.LogMessage = serializeService.SerializeObjectT(textMessage);

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
