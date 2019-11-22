using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotsRestServices.Models.Objects.AnswersFromServer
{
    /// <summary>
    /// Bots, that client has
    /// </summary>
    public class ActiveBot
    {
        public string BotName { get; set; }
        public bool BotStatus { get; set; }
    }
}