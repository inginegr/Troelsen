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
            FunWithEntitySQL();
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
                var carToDelete = (from c in context.Cars where c.CarID == 2222 select c).FirstOrDefault();
                if (carToDelete != null)
                {
                    context.DeleteObject(carToDelete);
                    context.SaveChanges();
                }
            }
        }
        private static void UpdateRecord()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                EntityKey key = new EntityKey("AutoLotEntities.Cars", "CarID", 2222);
                Car carToUpdate = null;
                try
                {
                    carToUpdate = (Car)context.GetObjectByKey(key);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (carToUpdate != null)
                {
                    carToUpdate.Color = "Blue";
                    context.SaveChanges();
                }
            }
        }
        private static void ShowSomeElements(int nm)
        {
            using (AutoLotEntities cntx = new AutoLotEntities())
            {
                var carToShow = from c in cntx.Cars where c.CarID < nm select c;
                if (carToShow != null)
                {
                    foreach (var n in carToShow)
                        Console.WriteLine(n.CarNickName);
                }
            }
        }

        private static void FunWithLINQQueries()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                var allData = (from item in context.Cars select item).ToArray();
                var colr = from cl in allData where cl.CarID < 6 select new { cl.CarNickName, cl.Color };
                foreach (var cl in colr)
                    Console.WriteLine(cl);
                var idsLessThanNumber = from sm in context.Cars where sm.CarID < 6 select sm;
                foreach (var s in idsLessThanNumber)
                    Console.WriteLine(s);
            }
        }

        private static void FunWithEntitySQL()
        {
            using (EntityConnection cn=new EntityConnection("name=AutoLotEntities"))
            {
                cn.Open();
                string query = "SELECT VALUE car FROM AutoLotEntities.Cars AS car";

                using (EntityCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = query;

                    using (EntityDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        try
                        {
                            while (dr.Read())
                            {
                                Console.WriteLine("***RECORD***");
                                Console.WriteLine("ID: {0}", dr["CarID"]);
                                Console.WriteLine("Make: {0}", dr["Make"]);
                                Console.WriteLine("Color: {0}", dr["Color"]);
                                Console.WriteLine("Pet Name: {0}", dr["CarNickName"]);
                                Console.WriteLine();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                }
            }
        }
    }
}