using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotsRestServices.Models.InterfaceServices;
using System.IO;
using ServiceLibrary.Serialization;


namespace BotsRestServices.Controllers.Interface
{
    public class InterfaceController : Controller
    {
        InterfaceService iserv = new InterfaceService();

        // GET: Interface
        [HttpGet]
        public ActionResult Index()
        {
            iserv.SendDataToStartPage(this);

            return View();
        }

        // POST: Interface/Authorize
        [HttpPost]
        public JsonResult Authorize()
        {
            return Json("sdf");
        }

        
    }
}
