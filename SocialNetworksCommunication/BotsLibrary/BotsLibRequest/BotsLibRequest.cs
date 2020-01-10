using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotsRestServices.Models.Objects.BotsLibRequest
{
    /// <summary>
    /// Request to bots library with some parameters
    /// </summary>
    public class BotsLibRequest
    {
        /// <summary>
        /// secret key of bot
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Any secondary parameters
        /// </summary>
        public string[] AddsParams { get; set; }

        /// <summary>
        /// Id of bot
        /// </summary>
        public int BotId { get; set; }

        /// <summary>
        /// Pathes to object of bot
        /// </summary>
        public string BotObjectPathes { get; set; }

        /// <summary>
        /// Command to start in bots library
        /// </summary>
        public string CommandToRun { get; set; }
    }
}