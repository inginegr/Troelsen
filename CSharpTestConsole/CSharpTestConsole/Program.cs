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





namespace CSharpTestConsole
{

    public partial class Inventory
    {
        public override string ToString()
        {
            return $"{this.CarID} \t {this.Color} \t\t {this.Make} \t\t {this.PetName}";
        }
    }

    class Program
    {   
        static void Main()
        {
            Console.WriteLine("***Entity Framework***");
            Console.WriteLine("CarID \t Color \t\t Make \t\t PetName \n");

            ShowAllInventories();
            Console.ReadLine();
        }

        private static int AddNewRecord()
        {
            AutoLotEntities context = new AutoLotEntities();
            try
            {
                Inventory inv = new Inventory { CarID=12, Color = "White", Make = "Honda", PetName = "Accord" };
                context.Inventories.Add(inv);
                context.SaveChanges();
                return inv.CarID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }            
        }

        private static void ShowAllInventories()
        {
            try
            {
                AutoLotEntities ent = new AutoLotEntities();
                var st = from c in ent.Inventories where c.Make=="Toyota" select new { c.CarID, c.Color, c.Make, c.PetName };
                foreach (var i in st)
                    Console.WriteLine(i);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}