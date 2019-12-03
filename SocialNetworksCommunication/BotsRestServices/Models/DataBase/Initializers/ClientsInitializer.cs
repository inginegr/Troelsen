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

            UserData ud1 = new UserData { Login = "Navi", Password = "boti" };
            UserData ud2 = new UserData { Login = "Godi", Password = "basdoti" };
            UserData ud3 = new UserData { Login = "bavi", Password = "boewr" };
            UserData ud4 = new UserData { Login = "Savi", Password = "345" };
            userList.Add(ud1);
            userList.Add(ud2);
            userList.Add(ud3);
            userList.Add(ud4);
            context.UserTable.AddOrUpdate(userList.ToArray());

            List<UserBot> botList = new List<UserBot>();
            UserBot ub1 = new UserBot { BotName = "Viber", BotStatus = true, UserData=ud1 };
            UserBot ub2 = new UserBot { BotName = "VK", BotStatus = true, UserData=ud1 };
            UserBot ub3 = new UserBot { BotName = "Telegram", BotStatus = true, UserData=ud1 };
            UserBot ub4 = new UserBot { BotName = "WhatsApp", BotStatus = true, UserData=ud1 };
            botList.Add(ub1);
            botList.Add(ub2);
            botList.Add(ub3);
            botList.Add(ub4);
            context.BotsTable.AddOrUpdate(botList.ToArray());

            List<BotObject> objectList = new List<BotObject>();
            BotObject bo1 = new BotObject { PathToObject = "dsfdsf", UserBot = ub1 };
            BotObject bo2 = new BotObject { PathToObject = "aaaa", UserBot = ub1 };
            BotObject bo3 = new BotObject { PathToObject = "vvvv", UserBot = ub1 };
            BotObject bo4 = new BotObject { PathToObject = "yyyu", UserBot = ub2 };
            BotObject bo5 = new BotObject { PathToObject = "3334e", UserBot = ub3 };
            objectList.Add(bo1);
            objectList.Add(bo2);
            objectList.Add(bo3);
            objectList.Add(bo4);
            objectList.Add(bo5);
            context.BotObjectsTable.AddOrUpdate(objectList.ToArray());

            base.Seed(context);
        }
    }
}