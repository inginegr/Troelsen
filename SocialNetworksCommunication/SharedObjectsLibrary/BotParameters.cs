﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjectsLibrary
{
    public enum BotTypes
    {
        VkBot,
        TgBot,
        ViberBot,
        FbBot
    }

    public class BotParameters
    {
        public int BotId { get; set; }
        public string CommandToRun { get; set; }
        public string SecretKey { get; set; }
        public string JsonFromServer { get; set; }
        public BotObject[] BotObjects { get; set; }
        public List<string> AdditionParameters { get; set; }
        public object AdditionObject { get; set; }
        public BotTypes BotType { get; set; }
    }
}
