﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects.SendMessageTypes
{
    public class ViberTextMessage : ViberMessageBasic 
    {
        public string receiver { get; set; }
        public string text { get; set; }
        public string min_api_version { get; set; }
    }
}
