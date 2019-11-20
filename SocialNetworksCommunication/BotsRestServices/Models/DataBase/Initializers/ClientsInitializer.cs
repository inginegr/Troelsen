using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using BotsRestServices.Models.Objects.DbObjects;
using BotsRestServices.Models.DataBase.Infrastructure;
using System.Data.Entity.Migrations;



namespace BotsRestServices.Models.DataBase.Initializers
{
    class ClientsInitializer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            UserData user = new UserData();
            List<UserData> userList = new List<UserData>();

            userList.Add(new UserData { Id = 0, Login = "Client", Password = "1234", TelegramBot = false, ViberBot = false, VkBot = false, WhatsAppBot = false });
            userList.Add(new UserData { Id = 1, Login = "Dima", Password = "12", TelegramBot = false, ViberBot = false, VkBot = false, WhatsAppBot = false });
            userList.Add(new UserData { Id = 1, Login = "Foty", Password = "1dsf2", TelegramBot = false, ViberBot = false, VkBot = false, WhatsAppBot = false });
            userList.Add(new UserData { Id = 1, Login = "Bomk", Password = "1dsfsdf2", TelegramBot = false, ViberBot = false, VkBot = false, WhatsAppBot = false });
            userList.Add(new UserData { Id = 1, Login = "Molka", Password = "12fgh", TelegramBot = false, ViberBot = false, VkBot = false, WhatsAppBot = false });
            userList.Add(new UserData { Id = 1, Login = "Jimmy", Password = "1245", TelegramBot = false, ViberBot = false, VkBot = false, WhatsAppBot = false });
            userList.Add(new UserData { Id = 1, Login = "Suzuki", Password = "143tr2", TelegramBot = false, ViberBot = false, VkBot = false, WhatsAppBot = false });
            userList.Add(new UserData { Id = 1, Login = "Hodna", Password = "1ert2gfh", TelegramBot = false, ViberBot = false, VkBot = false, WhatsAppBot = false });
            userList.Add(new UserData { Id = 1, Login = "Mitsubishi", Password = "12ert43", TelegramBot = false, ViberBot = false, VkBot = false, WhatsAppBot = false });
            userList.Add(new UserData { Id = 1, Login = "Toyota", Password = "fgh", TelegramBot = false, ViberBot = false, VkBot = false, WhatsAppBot = false });
            userList.Add(new UserData { Id = 1, Login = "CSS", Password = "n", TelegramBot = false, ViberBot = false, VkBot = false, WhatsAppBot = false });
            userList.Add(new UserData { Id = 1, Login = "HTML", Password = "tert", TelegramBot = false, ViberBot = false, VkBot = false, WhatsAppBot = false });
            userList.Add(new UserData { Id = 1, Login = "Noty", Password = "xcvcxgf", TelegramBot = false, ViberBot = false, VkBot = false, WhatsAppBot = false });


            context.UserTable.AddOrUpdate(userList.ToArray());

            base.Seed(context);
        }
    }
}