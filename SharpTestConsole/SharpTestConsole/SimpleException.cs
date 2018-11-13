using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Configuration;
using System.Data.Common;
using AutoLotConnectedLayer;

namespace MyConnectionFactory
{
    class Programm
    {
        static void Main()
        {
            Console.WriteLine("*** Simple Transaction Example ***\n");

            DataSet dts = new DataSet("Car Inventory");
            dts.ExtendedProperties["TimeStamp"] = DateTime.Now;
            dts.ExtendedProperties["DataSetID"] = Guid.NewGuid();
            dts.ExtendedProperties["Company"] = "Mikko's Hot Tub Super Store";

            Console.ReadLine();
        }
        static void FillDataSet(DataSet ds)
        {
            DataColumn dcCarID = new DataColumn("CarID", typeof(int));
            dcCarID.ReadOnly = true;
            dcCarID.Unique = true;
            dcCarID.AllowDBNull = false;
            dcCarID.Caption = "Car ID";
            dcCarID.AutoIncrement = true;
            dcCarID.AutoIncrementSeed = 0;
            dcCarID.AutoIncrementStep = 1;
            DataColumn dcMake = new DataColumn("Make", typeof(string));
            DataColumn dcColor = new DataColumn("Color", typeof(string));
            DataColumn dcPetName = new DataColumn("PetName", typeof(string));
            dcPetName.Caption = "Pet Name";
            DataTable dt = new DataTable("Inventory");
            dt.Columns.AddRange(new DataColumn[] { dcCarID, dcMake, dcColor, dcPetName });
        }
    }
}