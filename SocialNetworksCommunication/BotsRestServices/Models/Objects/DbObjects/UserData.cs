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
        public int Id { get; set; }

        public List<UserBot> Bots { get; set; }

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