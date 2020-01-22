using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotsRestServices.Models.UserServices;



namespace BotsRestServices.Controllers.Interface
{
    public class ClientController : Controller
    {
        //ClientService client = new ClientService();

        [HttpPost]
        public JsonResult GetBots()
        {
            return Json("sad");
        }

        [HttpPost]
        public JsonResult RestartBot()
        {
            return Json("asdsd");
        }

        [HttpPost]
        public JsonResult ApplyStatus()
        {
            return Json("asdasd");
        }
        
    }
}
