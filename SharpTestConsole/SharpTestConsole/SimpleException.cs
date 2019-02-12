using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Net;
using System.IO;
using System.Data.Common;
using System.Data.SqlClient;



[assembly:CLSCompliant(true)]

namespace MagicEightBallServiceHost
{
    
    class Program
    {
        private static string theEbook = null;
        enum me
        {
            one, two, three
        }
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(".");
            FileInfo[] s = di.GetFiles();
            foreach(FileInfo f in s)
                Console.WriteLine(f.Name);
            object sd;
            Enum.IsDefined(typeof(me), "dsfsdf");


            Console.ReadLine();
        }
    }
}