using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.EntityClient;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Remoting.Messaging;


[assembly:CLSCompliant(true)]

namespace MagicEightBallServiceHost
{
    public delegate int BinarOp(int x, int y);

    class Program
    {
        
        static void Main(string[] args)
        {
            WaitCallback wcb = new WaitCallback(PrintNum);
            ThreadPool.QueueUserWorkItem(wcb, "Hello");


            Console.ReadLine();
        }

        public static void PrintNum(object inb)
        {
            Console.WriteLine("{0} + {1}", (string)inb , DateTime.Now.ToLongTimeString());
            
        }

        public static void asclbc(IAsyncResult ia)
        {            
            Console.WriteLine("Ended");
            AsyncResult ac = (AsyncResult)ia;
            BinarOp bo = (BinarOp)ac.AsyncDelegate;
            Console.WriteLine("Adding operation  {0}", bo.EndInvoke(ia));
             
        }
        public static int Add(int x, int y)
        {
            Console.WriteLine("Adding");
            Console.WriteLine(x + y);
            Thread.Sleep(500);
            return x + y;
        }
    }
}