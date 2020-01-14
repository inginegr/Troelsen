using System;
using System.Reflection;
using System.Collections.Generic;

namespace onespace
{
    public static class Hm
    {
        public static void Hel(int st)
        {
            Console.WriteLine(st.ToString());
        }

        public static int retint(int u)
        {
            return u;
        }
    }
    public class Example
    {
        public class Par
        {
            public int y { get; set; }
        }

        public static void Main()
        {
            Assembly asm = Assembly.LoadFrom("C:\\Users\\Dima\\Documents\\GitHub\\Troelsen\\TempConsole\\TempConsole\\libs\\ClassLibrary1.dll");

            Type tp = asm.GetType("ClassLibrary1.Class1");
                        
            object ob = Activator.CreateInstance(tp);

            tp.InvokeMember("cnsl", BindingFlags.InvokeMethod, null, ob, new object[] { 33 });

                   
            
            Console.ReadLine();
        }
    }
}
