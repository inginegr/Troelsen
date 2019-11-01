﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotsRestServices.Controllers.RestServices
{
    [Produces("application/json")]
    [Route("api/Viber")]
    public class ViberController : Controller
    {
        // GET: api/Viber
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Viber/5
        [HttpGet("{id}", Name = "GetViber")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Viber
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Viber/5
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
