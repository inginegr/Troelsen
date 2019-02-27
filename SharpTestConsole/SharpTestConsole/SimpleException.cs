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
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            myc ms = new mys();
            ms.s1 = "s11";
            ms.s2 = "s2";
            ms.s3 = "s3";

            

            try
            {
                XmlSerializer xser = new XmlSerializer(typeof(mys));

                Stream fstr = new FileStream("mt.xml", FileMode.Create, FileAccess.Write, FileShare.None);
                xser.Serialize(fstr, ms);
                fstr.Close();

                fstr = new FileStream("mt.xml", FileMode.Open);

                myc vm = new myc();
                Console.WriteLine($"{vm.s1}  {vm.s2}   {vm.s3}");
                vm = (myc)xser.Deserialize(fstr);
                Console.WriteLine($"{vm.s1}  {vm.s2}   {vm.s3}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


    Console.ReadLine();
        }
    }
}