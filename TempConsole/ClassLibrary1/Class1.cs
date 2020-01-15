using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalLib;
using SharedObjectsLibrary;

namespace ClassLibrary1
{    
    public class Class1
    {
        AddLib adl = new AddLib();

        public void cnsl(SharedObject sh)
        {
            Console.WriteLine($"The x is {sh.X} and string {sh.St}");
        }
    }
}
