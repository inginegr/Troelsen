using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.Objects.DbObjects;


namespace BotsRestServices.Models.Objects.AnswersFromServer
{
    public class TotalResponse 
    {
        private int numberBots = 4;
        public IsAdmin Admin { get; set; }
        public IsClient Client { get; set; }
        public UserData[] Users { get; set; }
        public User UserAuth { get; set; }
        public IsTrueAnswer IsTrue { get; set; }
        public ErrorResponse Error { get; set; }
        public ActiveBot[] Bots { get; set; }

        public TotalResponse() : this(usersCount: 1) { }

        public TotalResponse(int usersCount)
        {
            Admin = new IsAdmin();
            Client = new IsClient();
            Users = new UserData[usersCount];
            UserAuth = new User();
            IsTrue = new IsTrueAnswer();
            Error = new ErrorResponse();
            Bots = new ActiveBot[numberBots];
        }
    }
}