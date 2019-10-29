using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialNetworksRESTServices.Controllers
{
    public class VKController : ApiController
    {
        // GET: api/VK
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/VK/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/VK
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/VK/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VK/5
        public void Delete(int id)
        {
        }
    }
}
