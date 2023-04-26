using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalLib;
using SharedObjectsLibrary;

namespace ClassLibrary1
{    
    public class DemoClass : MarshalByRefObject
    {
        public void prnt(string s)
        {
            Console.WriteLine($"The string is {s}");
        }
    }
}
