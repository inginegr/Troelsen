using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BotsRestServices.Models.Objects.DbObjects
{
    public class UserBot
    {
        public int Id { get; set; }

        public string BotName { get; set; }

        public bool BotStatus { get; set; }

        public List<BotObject> BotObject { get; set; }

        public int? UserDataId { get; set; }

        public UserData UserData { get; set; }

        public UserBot()
        {
            BotObject = new List<DbObjects.BotObject>();
        }
    }
}