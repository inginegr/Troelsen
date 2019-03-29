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
            int[] tt = new int[3];
            tt[0] = 1;
            tt[1] = 2;
            tt[2] = 2;

            int[] pp = new int[3];
            pp[0] = 9;
            pp[1] = 8;
            pp[2] = 7;


            Console.WriteLine($"{tt[0]}   {tt[1]}   {tt[2]}");
            tt = pp;
            Console.WriteLine($"{tt[0]}   {tt[1]}   {tt[2]}");




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