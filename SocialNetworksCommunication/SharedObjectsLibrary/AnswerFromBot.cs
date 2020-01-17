﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjectsLibrary
{
    public class AnswerFromBot
    {
        /// <summary>
        /// Success operation or no
        /// </summary>
        public bool IsTrue { get; set; }

        /// <summary>
        /// Addition information from bot
        /// </summary>
        public string LogMessage { get; set; }
    }
}