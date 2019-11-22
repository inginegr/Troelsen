using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using BotsRestServices.Models.Objects.DbObjects;
using BotsRestServices.Models.Objects.AnswersFromServer;


namespace BotsRestServices.Models.Objects.RequestToServer
{
    public class CommandData
    {
        public UserData User { get; set; }
       
        public string ClientCommand { get; set; }
    }
}