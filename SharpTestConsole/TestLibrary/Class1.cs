using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class TST
    {
        string S1 { get; set; }
        string S2 { get; set; }
        public string S3 { get; set; }
        public string S4 { get; set; }
        public void tPrint() { Console.WriteLine("{0}   {1}", S1, S2); }
        public void tEmp(string a,string b) { Console.WriteLine("{0}   {1}", a, b); }
        public TST() { }
        public TST(string a,string b)
        {
            S1 = a;
            S2 = b;
        }
    }
}
