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
        public JsonResult SaveClientsData()
        {
            return Json(admin.EditClients(this));
        }

        [HttpPost]
        public JsonResult DeleteClient()
        {
            return Json(admin.RemoveClientFromDb(this));
        }        
    }
}
