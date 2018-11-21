using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.EntityClient;
using SharpTestConsole;

namespace MyConnectionFactory
{
    class Programm
    {
        static void Main()
        {
            Console.WriteLine("*** Fun with with ADO.net EF ***");
            AddNewRecord();
            PrintAllInventory();

            Console.ReadLine();
        }
        private static void AddNewRecord()
        {
            using (AutoLotEntities contex = new AutoLotEntities())
            {
                try
                {
                    contex.Cars.AddObject(new Car()
                    {
                        CarID = 2222,
                        Make = "Yugo",
                        Color = "Brown"
                    });
                    contex.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static void PrintAllInventory()
        {
            using(AutoLotEntities context=new AutoLotEntities())
            {
                foreach (Car c in context.Cars)
                    Console.WriteLine(c);
            }
            
        }
        private static void RemoveRecord()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                EntityKey key = new EntityKey("AutolotEntities.Cars", "CarID", 2222);
                Car carToDelete = (Car)context.GetObjectByKey(key);
                if(carToDelete!=null)
                {
                    context.DeleteObject(carToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}