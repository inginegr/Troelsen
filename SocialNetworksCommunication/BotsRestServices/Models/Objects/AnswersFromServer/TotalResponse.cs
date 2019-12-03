using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.Objects.DbObjects;


namespace BotsRestServices.Models.Objects.AnswersFromServer
{
    public class TotalResponse 
    {
        public IsAdmin Admin { get; set; }
        public IsClient Client { get; set; }
        public UserData UserAuth { get; set; }
        public IsTrueAnswer IsTrue { get; set; }
        public List<UserData> Users { get; set; }

        public TotalResponse()
        {
            Admin = new IsAdmin();
            Client = new IsClient();
            UserAuth = new UserData();
            IsTrue = new IsTrueAnswer();
            Users = new List<UserData>();
        }
    }
}