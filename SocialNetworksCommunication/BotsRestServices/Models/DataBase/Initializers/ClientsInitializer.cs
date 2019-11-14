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


            context.UserTable.AddOrUpdate(userList.ToArray());

            base.Seed(context);
        }
    }
}