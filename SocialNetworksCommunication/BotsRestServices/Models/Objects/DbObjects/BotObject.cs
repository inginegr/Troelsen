using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotsRestServices.Models.Objects.DbObjects
{
    public class BotObject
    {
        public int Id { get; set; }

        public string PathToObject { get; set; }

        public int? UserBotId { get; set; }

        public UserBot UserBot { get; set; }
    }
}