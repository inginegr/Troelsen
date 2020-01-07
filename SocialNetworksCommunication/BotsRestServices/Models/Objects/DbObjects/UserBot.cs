using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BotsRestServices.Models.Objects.DbObjects
{
    public class UserBot
    {
        public int Id { get; set; }

        public string BotName { get; set; }

        public bool BotStatus { get; set; }

        [JsonIgnore]
        public virtual List<BotObject> BotObject { get; set; }

        public int? UserDataId { get; set; }
        [JsonIgnore]
        public UserData UserData { get; set; }

        public UserBot()
        {
            BotObject = new List<BotObject>();
        }
    }
}