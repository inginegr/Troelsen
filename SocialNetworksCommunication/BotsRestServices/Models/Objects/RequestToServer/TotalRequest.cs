using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.Objects.DbObjects;



namespace BotsRestServices.Models.Objects.RequestToServer
{
    public class TotalRequest
    {
        public UserData User { get; set; }
        public string ComandType { get; set; }

        public CommandData DataRequest { get; set; }


        public TotalRequest()
        {
            User = new UserData();
            DataRequest = new CommandData();
        }
    }
}