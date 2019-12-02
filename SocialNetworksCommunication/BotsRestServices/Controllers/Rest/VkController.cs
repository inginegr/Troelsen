using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BotsRestServices.Controllers.Rest
{
    public class VkController : ApiController
    {
        // GET: api/Vk
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Vk/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vk
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Vk/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vk/5
        public void Delete(int id)
        {
        }
    }
}
