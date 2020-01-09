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
            Type t = Type.GetType("onespace.Hm");
            MethodInfo mi = t.GetMethod("Hel");

            var v = t.InvokeMember("retint", BindingFlags.InvokeMethod, null, null, new object[] { 43 }, null);

            Console.WriteLine(v);
            
            Console.ReadLine();
        }
    }
}
