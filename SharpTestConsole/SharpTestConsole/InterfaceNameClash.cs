using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTestConsole
{
    interface IDrawable { void Draw(); }
    interface IPrintable
    {
        void Print();
        void Draw(); // Conflict of names may be
    }
    interface IShape : IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }
}
