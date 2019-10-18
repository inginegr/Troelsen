using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworks.TGObjects;



namespace SocialNetworks.Telegramm
{

    public partial class TGCommunicate
    {
        /// <summary>
        /// Sends message to some user or chat id
        /// </summary>
        /// <param name="chatId">Id of chat or user id</param>
        /// <param name="messageString">Message to sent</param>
        /// <param name="dictionary">Dictionary with  parametres</param>
        /// <returns></returns>
        public bool SendMessage(IDictionary<string, string> dictionary)
        {
            try
            {
                string answer = SendRequest("sendMessage", dictionary);

                List<TGAnswerToRequest> updateObjects = (List<TGAnswerToRequest>)jso.DeserializeToList<TGAnswerToRequest>(answer, new string[] { "result" });

                if (string.Compare(answer, dictionary["text"]) > 0)
                    return true;
                else
                    return false;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
