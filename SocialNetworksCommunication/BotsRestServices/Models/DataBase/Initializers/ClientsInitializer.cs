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

            context.UserTable.AddOrUpdate(user);

            base.Seed(context);
        }
    }
}