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


        public static void Main()
        {
            Assembly asm = Assembly.LoadFrom("C:\\Users\\Dima\\Documents\\GitHub\\Troelsen\\TempConsole\\TempConsole\\libs\\ClassLibrary1.dll");

            Type tp = asm.GetType("ClassLibrary1.Class1");

            object inst = Activator.CreateInstance(tp);

            tp.InvokeMember("cnsl", BindingFlags.InvokeMethod, null, inst, new object[] { 234 }, null);
           


            Console.ReadLine();
        }
    }
}
