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
        public JsonResult AddUsers()
        {
            return Json(admin.AddRowsToDb(this));
        }

        [HttpPost]
        public JsonResult GetUsersList()
        {            
            return Json(admin.GetClientsList(this));
        }

        [HttpPost]
        public JsonResult GetBotsList()
        {
            return Json(admin.GetBotsList(this));
        }

        [HttpPost]
        public JsonResult GetBotObjectsList()
        {
            return Json(admin.GetBotObjectsList(this));
        }

        [HttpPost]
        public JsonResult SaveClientsData()
        {
            return Json(admin.EditEntries(this));
        }

        [HttpPost]
        public JsonResult DeleteRows()
        {
            return Json(admin.RemoveRowsFromDb(this));
        }

        [HttpPost]
        public JsonResult EditRows()
        {
            return Json(admin.EditEntries(this));
        }
    }
}
