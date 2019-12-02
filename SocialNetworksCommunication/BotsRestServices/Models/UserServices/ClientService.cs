using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BotsRestServices.Models.DataBase.Infrastructure;
using BotsRestServices.Models.Objects.DbObjects;
using BotsRestServices.Models.Objects.AnswersFromServer;
using BotsRestServices.Models.Objects.RequestToServer;


namespace BotsRestServices.Models.UserServices
{
    public class ClientService: UserService
    {
        public string GetClientBots(Controller ctr)
        {
            TotalResponse response = null;

            try
            {
                string requestString = ReadDataFromBrowser(ctr);
                TotalRequest request = GetRequestObject(requestString);
                response = FormLogPas(request.User);

                UserData client = dbHandle.GetUsers()
                    .Where(a => ((request.User.Id==a.Id)&&(request.User.Login==a.Login) && (request.User.Password == a.Password)))
                    .FirstOrDefault();
                
                foreach(UserBot u in client.Bots)
                {
                    response.Bots.Add(u);
                }

                response = FormResponseStatus(response, true, $"The bots of client is gotten");
            }
            catch (Exception ex)
            {
                response = FormResponseStatus(response, false, ex.Message);
            }
            return js.SerializeObjectT(response);
        }
    }
}