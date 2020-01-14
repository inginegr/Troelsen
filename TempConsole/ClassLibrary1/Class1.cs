using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalLib;

namespace ClassLibrary1
{    
    public class Class1
    {
        AddLib adl = new AddLib();

        public void cnsl(int x)
        {
            int num = adl.mp(x);
            Console.WriteLine($"The x is {num}");
        }
    }
}
