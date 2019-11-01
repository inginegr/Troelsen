using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotsRestServices.Controllers.RestServices
{
    [Produces("application/json")]
    [Route("api/VK")]
    public class VKController : Controller
    {
        // GET: api/VK
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/VK/5
        [HttpGet("{id}", Name = "GetVK")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/VK
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/VK/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
