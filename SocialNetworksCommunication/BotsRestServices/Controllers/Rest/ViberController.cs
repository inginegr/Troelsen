using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BotsRestServices.Controllers.Rest
{
    public class ViberController : ApiController
    {
        // GET: api/Viber
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Viber/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Viber
        public void Post([FromBody]string value)
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
