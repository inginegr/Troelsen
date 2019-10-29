using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialNetworksRESTServices.Controllers
{
    public class TelegramController : ApiController
    {
        // GET: api/Telegram
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Telegram/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Telegram
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Telegram/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Telegram/5
        public void Delete(int id)
        {
        }
    }
}
