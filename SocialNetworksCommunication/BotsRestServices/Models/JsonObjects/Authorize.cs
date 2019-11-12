using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotsRestServices.Models.JsonObjects
{
    /// <summary>
    /// Authorize data
    /// </summary>
    public class Authorize
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}