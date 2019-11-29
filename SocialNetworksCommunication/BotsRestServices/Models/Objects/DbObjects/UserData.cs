using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BotsRestServices.Models.Objects.AnswersFromServer;



namespace BotsRestServices.Models.Objects.DbObjects
{
    public class UserData : User, ICloneable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public bool VkBot { get; set; }

        public bool TelegramBot { get; set; }

        public bool ViberBot { get; set; }

        public bool WhatsAppBot { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class UserBots
    {
        [Key]
        public int Id { get; set; }

        public List<string> Bots { get; set; }
    }
}