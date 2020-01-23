using System;
using System.Collections.Generic;
using BotsRestServices.Models.Objects.AnswersFromServer;
using Newtonsoft.Json;



namespace BotsRestServices.Models.Objects.DbObjects
{
    public class UserData : User, ICloneable
    {
        public int Id { get; set; }

        [JsonIgnore]
        public virtual List<UserBot> Bots { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public UserData()
        {
            Bots = new List<UserBot>();
        }
    }
}