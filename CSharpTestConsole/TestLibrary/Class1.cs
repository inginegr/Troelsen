using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDALEF;
using AutoLotDALEF.Repo;

namespace TestLibrary
{
    public class TST
    {
        static void Main()
        {
            
            Console.WriteLine("**** Fun with EntityFrameWork ****");
            try
            {
                var repo = new InventoryRepo();
                foreach (Inventory c in repo.GetAll())
                    Console.WriteLine(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}