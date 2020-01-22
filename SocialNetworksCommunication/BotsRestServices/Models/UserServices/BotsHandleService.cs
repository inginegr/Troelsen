using BotsRestServices.Models.BotServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.Objects.AnswersFromServer;

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

        //public string StartBot()
        //{
        //    TotalResponse response = new TotalResponse();
        //    try
        //    {

        //    }catch(Exception ex)
        //    {

        //    }
        //}
    }
}