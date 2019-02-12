using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Media;





namespace MyConnectionFactory
{
   class Program
    {   
        public delegate void BinaryOp(int x, int y);

        public class Mes : EventArgs
        {
            public string sommes { get; set; }
            public int somin { get; set; }
            public Mes(string s, int i)
            {
                sommes = s;
                somin = i;
            }
        }

        public class one : IEnumerable
        {
            public int X { get; set; }
            private ArrayList al = new ArrayList();

            public string this[int index]
            {
                
                get => (string)al[index];
                set => al.Insert(index, value);
            }

            public IEnumerator GetEnumerator()
            {
                return al.GetEnumerator();
            }
        }
        
        static void Main()
        {
            one[] ones = new one[]
            {
                new one { X=1 },
                new one { X=2 },
                new one { X=3 }
            };
            int sdf = 123213;
            
            one o = new one();
            o[0] = "3df";
            o[1] = "4gh";
            o[2] = "5rty";
            
            foreach (string oo in o)
                Console.WriteLine(oo);


            Console.ReadLine();
        }
        static bool mout(int n) => n % 5 == 2;
        static void mt(object sender, Mes sm) => Console.WriteLine(sm.sommes + " mt");
        static void mot(object sender, Mes sm) => Console.WriteLine(sm.somin.ToString());
    }
}