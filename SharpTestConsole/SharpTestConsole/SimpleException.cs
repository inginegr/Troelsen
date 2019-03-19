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
    public class myc
    {        
        public string s1 { get; set; }
        public string s2 { get; set; }
        public string s3 { get; set; }
        public int si { get; set; }
        int dd;
        //public myc() { }
        public myc()
        {
            s1 = "Hello";
            s2 = "my";
            s3 = "Frends";
            si = 12;
            dd = 45;
            int f = 9 + 5;
        }
        public override string ToString()
        {
            return $"{ s1}  {s2}  {s3}";
        }
    }

    [Serializable]
    public class mys
    {
        public string a1 { get; set; }
        public string a2 { get; set; }
        public string a3 { get; set; }
        public int uy { get; set; }
        public myc[] mc;

        public mys()
        {
            mc = new myc[2];
            //for (int i = 0; i < 2; i++)
            //    mc[i] = new myc ();
            uy = 5;
            a1 = "You";
            a2 = "are";
            a3 = "best";
            
        }
        public override string ToString()
        {
            return $"{ a1}  {a2}  {a3}";
        }
    }


    class Program
    {        
        static void Main(string[] args)
        {
            mys ms = new mys();

            Console.WriteLine("Before");

            XmlSerializer xsr = new XmlSerializer(typeof(mys));
            FileStream fs = new FileStream("ss.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xsr.Serialize(fs, ms);
            fs.Close();

            fs = new FileStream("ss.xml", FileMode.OpenOrCreate, FileAccess.Read);
            mys dd = (mys)xsr.Deserialize(fs);

            Console.WriteLine($"{dd.ToString()}  {dd.mc[0].ToString()}    {dd.mc[1].ToString()}");
            
            Console.ReadLine();
        }
    }
}