﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotsLibrary.ViberBots
{
    /// <summary>
    /// All Viber bots classe contain this interface
    /// </summary>
    interface IViberBot
    {
        string ViberBotsStartPoint(string[] addsParam, string jsonFromServer);
    }
}
