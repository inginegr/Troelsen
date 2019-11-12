using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotsRestServices.Models.InterfaceServices;
using System.IO;


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

        // POST: Interface/Authorize
        [HttpPost]
        public JsonResult Authorize()
        {
            string jsonPostData;

            using (Stream sr = Request.InputStream)
            {
                sr.Position = 0;
                using(StreamReader rd = new StreamReader(sr))
                {                    
                    jsonPostData = rd.ReadToEnd();
                }
            }

            return Json("sdf");
        }

        
    }
}
