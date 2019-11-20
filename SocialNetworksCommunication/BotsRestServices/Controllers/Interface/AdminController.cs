using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotsRestServices.Models.UserServices;


namespace BotsRestServices.Controllers.Interface
{
    public class AdminController : Controller
    {

        AdminService admin = new AdminService();

        // GET: Admin
        public JsonResult AddUser()
        {
            return Json("fds");
        }

        [HttpPost]
        public JsonResult GetUsersList()
        {            
            return Json(admin.GetClientsList(this));
        }

        [HttpPost]
        public JsonResult SaveClientData()
        {
            return Json(admin.EditClient(this));
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
