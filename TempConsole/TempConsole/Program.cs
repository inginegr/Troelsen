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

    public class Tmp
    {
        public string Tm { get => "hello"; }
    }

    public class Example
    {
        public class Par
        {
            public int y { get; set; }
        }

        public static void Main()
        {

            Tmp t = new Tmp();

            Console.WriteLine(t.Tm);
            
            Console.ReadLine();
        }
    }
}
