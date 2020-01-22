using BotsRestServices.Models.BotServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.Objects.AnswersFromServer;
using BotsRestServices.Models.Objects.RequestToServer;
using BotsRestServices.Models.Objects.DbObjects;

using System.Web.Mvc;



namespace BotsRestServices.Models.UserServices
{
    /// <summary>
    /// Make simple operations like remove, delete or edit bot objects 
    /// </summary>
    public class BotsHandleService : BaseBotService 
    {
        /// <summary>
        /// Form response string 
        /// </summary>
        /// <param name="IsTrue">Status of answer</param>
        /// <param name="mesToSend">Answer text</param>
        /// <param name="totalResponse">TotalResponse class answer from server</param>
        /// <returns>json string</returns>
        private string FormAnswerString(bool IsTrue, string mesToSend, TotalResponse totalResponse)
        {
            try
            {
                totalResponse.IsTrue.IsTrue = IsTrue;
                totalResponse.IsTrue.Text = mesToSend;
                return js.SerializeObjectT(totalResponse);
            }catch(Exception ex)
            {
                totalResponse.IsTrue.IsTrue = false;
                totalResponse.IsTrue.Text = $"Error occured inside FormAnswerString method: --> {ex.Message}";
                return js.SerializeObjectT(totalResponse);
            }
        }

        public string StartBot(Controller ctr)
        {
            TotalResponse response = new TotalResponse();
            try
            {
                TotalRequest req = jsd.DeserializeToObjectT<TotalRequest>(ReadDataFromBrowser(ctr));

                if (!CheckIfRegistered(req.User).IsTrue.IsTrue)
                {
                    return js.SerializeObjectT(FormResponseStatus(response, false, "User is not registered"));
                }
                else
                {
                    UserBot bot = (UserBot)FindRow(req.BotsList.FirstOrDefault());
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}