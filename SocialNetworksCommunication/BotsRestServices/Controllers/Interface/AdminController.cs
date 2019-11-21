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

        [HttpPost]
        public JsonResult AddUser()
        {
            return Json(admin.AddClientToDb(this));
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

        [HttpPost]
        public JsonResult DeleteClient()
        {
            return Json(admin.RemoveClientFromDb(this));
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
