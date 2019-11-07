using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotsRestServices.Models.InterfaceServices;


namespace BotsRestServices.Controllers.Interface
{
    public class InterfaceController : Controller
    {
        InterfaceService iserv = new InterfaceService();

        // GET: Interface
        [HttpGet]
        public ActionResult Index()
        {
            Random rn = new Random();

            iserv.SendDataToStartPage(this);


            return View();
        }

        // GET: Interface/Details/5
        [HttpPost]
        public JsonResult Authorize()
        {
            string name = "Tom";
            return Json(name);
        }

        
    }
}
