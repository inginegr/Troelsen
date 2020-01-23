using Newtonsoft.Json;
using System.Collections.Generic;

namespace BotsRestServices.Models.Objects.DbObjects
{
    public class UserBot
    {
        public int Id { get; set; }
                
        public string FriendlyBotName { get; set; }

        /// <summary>
        /// Defines basic bot name, that is equel to dll name. It may to have the name only from BotNames class
        /// </summary>
        public string BasicBotName { get; set; }

        /// <summary>
        /// Unique number of bot that added to end of the dll library name
        /// </summary>
        public int UniqueBotNumber { get; set; }
        
        //Unique key of every bot. The client may to change this parameter.
        public string SecretKey { get; set; }

        public bool BotStatus { get; set; }

        [JsonIgnore]
        public virtual List<BotObject> BotObject { get; set; }

        public int? UserDataId { get; set; }
        [JsonIgnore]
        public UserData UserData { get; set; }

        public UserBot()
        {
            BotObject = new List<BotObject>();
        }
    }
}