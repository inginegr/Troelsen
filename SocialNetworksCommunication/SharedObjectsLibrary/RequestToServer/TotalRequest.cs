using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotsRestServices.Models.Objects.DbObjects;
using SharedObjectsLibrary;


namespace BotsRestServices.Models.Objects.RequestToServer
{
    public class TotalRequest
    {
        public UserData User { get; set; }
        
        public List<UserData> ClientsList { get; set; }

        public List<UserBot> BotsList { get; set; }

        public List<BotObject> BotObjectsList { get; set; }

        public BotServiceData ServiceBot { get; set; }

        public TotalRequest()
        {
            User = new UserData();
            ClientsList = new List<UserData>();
            BotsList = new List<UserBot>();
            BotObjectsList = new List<BotObject>();
            ServiceBot = new BotServiceData();
        }
    }
}