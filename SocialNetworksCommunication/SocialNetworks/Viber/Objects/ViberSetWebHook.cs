﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworks.Viber.Objects
{
    public class ViberSetWebHook
    {
        public string Url { get; set; }
        public string[] Event_types { get; set; }
        public string Send_name { get; set; }
        public string Send_photo { get; set; }
    }
}