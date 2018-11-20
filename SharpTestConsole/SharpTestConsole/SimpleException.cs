using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Configuration;
using System.Data.Common;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AutoLotDisconnectedLayer;

namespace MyConnectionFactory
{
    class Programm
    {
        static void Main()
        {
            Console.WriteLine("*** Fun with data adapters ***");
            string cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            InventoryDALDisLayer dl = null;
            try
            {
                dl = new InventoryDALDisLayer(cnStr);
                DataTable dt = dl.GetAllInventory();
                ShowRedCars(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static void PrintAllCarIDs(DataTable data)
        {
            EnumerableRowCollection enumData = data.AsEnumerable();
            foreach (DataRow dt in enumData)
                Console.WriteLine("Car ID = {0}, Make = {1}, Color = {2}", dt["CarID"], dt["Make"], dt["Color"]);
        }

        static void ShowRedCars(DataTable data)
        {
            var cars = from car in data.AsEnumerable()
                       select car;
            Console.WriteLine("Here are the red cars we have in stock:");
            DataTable newTable = cars.CopyToDataTable();

            for (int row = 0; row < newTable.Rows.Count; row++)
            {
                for (int col = 0; col < newTable.Columns.Count; col++)
                {
                    Console.Write(newTable.Rows[row][col].ToString().Trim()+"\t");
                }
                Console.WriteLine();
            }

        }
    }
}