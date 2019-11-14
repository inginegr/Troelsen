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
        public UserData[] Users { get; set; }
        public IsTrueAnswer IsTrue { get; set; }

        public TotalResponse() : this(usersCount: 1) { }

        public TotalResponse(int usersCount)
        {
            Admin = new IsAdmin();
            Client = new IsClient();
            Users = new UserData[usersCount];
            IsTrue = new IsTrueAnswer();
        }
    }
}