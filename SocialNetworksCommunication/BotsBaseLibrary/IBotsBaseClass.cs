﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedObjectsLibrary;

namespace BotsBaseLibrary
{
    public interface IBotsBaseClass
    {
        AnswerFromBot EnterPoint(BotParameters botParameters);
    }
}
