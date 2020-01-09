using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;

namespace BotsRestServices.Controllers.Rest
{
    public class ViberController : ApiController
    {        
        // GET: api/Viber/5
        [System.Web.Mvc.HttpGet]
        public void Get()
        {
            
        }

        // POST: api/Viber
        public void Post()
        {

        }

        // PUT: api/Viber/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Viber/5
        public void Delete(int id)
        {
        }
    }
}
