using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BotsRestServices.Controllers.Interface
{
    public class AdminController : Controller
    {
        // GET: Admin
        public JsonResult AddUser()
        {
            return Json("fds");
        }

        public JsonResult DeleteUser()
        {
            return Json("fds");
        }

        public JsonResult BlockUser()
        {
            return Json("fds");
        }

        public JsonResult BlockBot()
        {
            return Json("fds");
        }

        public JsonResult AddBotToUser()
        {
            return Json("fds");
        }

        public JsonResult DeleteBotFromUser()
        {
            return Json("fds");
        }
    }
}
