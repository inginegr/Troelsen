﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTestConsole
{
    interface IPointy
    {
        byte Points { get; }
    }
    public interface IDraw3D
    {
        void Draw3D();
    }
}
