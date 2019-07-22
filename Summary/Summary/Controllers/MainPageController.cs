using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml;
using Summary.Models;

namespace Summary.Controllers
{
    
    public class MainPageController : Controller
    {
        private ProcessDb _db = new ProcessDb();

        // GET: MainPage
        public ActionResult SendPage(int id = 0)
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendRemainedXML()
        {
            //Path to XML text
            string st = Server.MapPath("~/Content/XML/AddHTMLData.xml");
            
            //Load XML data to XmlDocument object
            XmlDocument xml = new XmlDocument();
            xml.Load(st);

            // Return XML text
            return Content(xml.InnerXml, "text/xml");
        }

        [HttpPost]
        public ActionResult SendMessageToDevelopper()
        {
            // Status
            string retSt = null;

            // Add record to db
            try
            {
                string sa = Request.Form[0];
                _db.AddRecord(sa);
                retSt = "ok";
            }catch(Exception ex)
            {
                _db.WriteToLog(ex.Message);
                retSt = "false";
            }

            return Content(retSt, "text/xml");
        }

        [HttpPost]
        public ActionResult AdminEnter()
        {
            LocalCryptography lc = new LocalCryptography();
            ProcessDb pdb = new ProcessDb();

            string retSt = "ok";

            string st = Request.Form[0];

            try
            {
                if (lc.CheckIfUserAuth(st))
                {                    
                    string param = st.Split(' ')[4];

                    if (param == "readDb")
                    {
                        retSt += pdb.GetData();
                    }

                    if (param == "clearDb")
                    {
                        retSt = pdb.RemoveRecords().ToString();
                    }
                }
                else
                {
                    retSt = "false";
                }
            }
            catch ( Exception ex)
            {
                retSt = "false";
                pdb.WriteToLog(ex.Message);
            }

            return Content(retSt, "text/xml");
        }
    }
}