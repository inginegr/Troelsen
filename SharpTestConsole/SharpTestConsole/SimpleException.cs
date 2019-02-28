using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;



namespace MagicEightBallServiceHost
{
    [Serializable]
    [XmlType]
    public class myc
    {        
        public string s1 { get; set; }
        public string s2 { get; set; }
        public string s3 { get; set; }

        public myc()
        {
            s1 = "Hello";
            s2 = "my";
            s3 = "Frends";
        }
        public override string ToString()
        {
            return $"{ s1}  {s2}  {s3}";
        }
    }

    public class mys : myc
    {
        public string a1 { get; set; }
        public string a2 { get; set; }
        public string a3 { get; set; }

        public mys()
        {
            a1 = "You";
            a2 = "are";
            a3 = "best";
        }
        public override string ToString()
        {
            return $"{ a1}  {a2}  {a3}  { s1}  {s2}  {s3}";
        }
    }


    class Program
    {        
        static void Main(string[] args)
        {
            myc mc = new myc();
            mc.s1 = "one";
            mc.s2 = "two";
            mc.s3 = "three";
            mys ms = new mys();

            Console.WriteLine("Before");

            Console.WriteLine(ms.ToString());

            ms = (mys)mc;
            Console.WriteLine("After");
            Console.WriteLine(ms.ToString());
            
            Console.ReadLine();
        }
    }
}