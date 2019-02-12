using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDALEF;

namespace TestLibrary
{
    public class TST
    {
        static void Main()
        {
            Console.WriteLine("**** Fun with EntityFrameWork ****");
            try
            {
                Database.SetInitializer(new MyDataInitializer());
                var cont = new AutoLotEntities();
                foreach (Customer c in cont.Customers)
                    Console.WriteLine("{0}  {1}  {2}", c.CustID, c.FirstName, c.LastName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}