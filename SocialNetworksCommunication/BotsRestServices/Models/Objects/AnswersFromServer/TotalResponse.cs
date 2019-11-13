using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BotsRestServices.Models.Objects.AnswersFromServer
{
    public class TotalResponse
    {
        public IsAdmin Admin { get; set; }
        public IsClient Client { get; set; }
        public User LogPas { get; set; }
        public IsTrueAnswer IsTrue { get; set; }
    }
}