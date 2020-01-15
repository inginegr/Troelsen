using System;
using System.Reflection;
using System.Collections.Generic;
using SharedObjectsLibrary;

namespace onespace
{
    public class Example
    {
        public static void Main()
        {
            Assembly asm = Assembly.LoadFrom("C:\\Users\\Dima\\Documents\\GitHub\\Troelsen\\TempConsole\\TempConsole\\libs\\ClassLibrary1.dll");

            Type tp = asm.GetType("ClassLibrary1.Class1");

            object obj = Activator.CreateInstance(tp);

            tp.InvokeMember("cnsl", BindingFlags.InvokeMethod, null, obj, new object[] { new SharedObject { X = 3, St = "sss" } });
                        
            Console.ReadLine();
        }
    }
}
