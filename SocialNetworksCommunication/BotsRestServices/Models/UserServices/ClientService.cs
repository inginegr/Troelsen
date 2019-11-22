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
                
                response.Bots[0] = new ActiveBot { BotName = "Viber Bot", BotStatus = client.ViberBot };
                response.Bots[1] = new ActiveBot { BotName = "Vk Bot", BotStatus = client.VkBot };
                response.Bots[2] = new ActiveBot { BotName = "Telegramm Bot", BotStatus = client.TelegramBot };
                response.Bots[3] = new ActiveBot { BotName = "WhatsApp Bot", BotStatus = client.WhatsAppBot };


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