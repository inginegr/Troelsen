using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BotsRestServices.Models.Objects.AnswersFromServer;
using BotsRestServices.Models.Objects.DbObjects;


namespace BotsRestServices.Models.DataBase.Infrastructure
{
    class UserContext : DbContext 
    {
        public UserContext() : base("DefaultConnection") { }
        public UserContext(string connectionString) : base(connectionString) { }

        public DbSet<UserData> UserTable { get; set; }
    }
}