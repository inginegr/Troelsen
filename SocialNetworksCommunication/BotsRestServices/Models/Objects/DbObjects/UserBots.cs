using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BotsRestServices.Models.Objects.DbObjects
{
    public class UserBots
    {
        [Key]        
        public int Id { get; set; }

        public string BotName { get; set; }

        public bool BotStatus { get; set; }
        
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}