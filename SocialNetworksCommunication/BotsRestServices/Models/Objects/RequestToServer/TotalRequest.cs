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

        public List<UserData> UserList { get; set; }



        public TotalRequest()
        {
            User = new UserData();
            UserList = new List<UserData>(); 
        }
    }
}