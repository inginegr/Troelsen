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
using AutoLotConnectedLayer;

namespace MyConnectionFactory
{
    class Programm
    {
        static void Main()
        {
            Console.WriteLine("*** Fun with data adapters ***");
            string cnStr = "Integrated Security =SSPI; Initial Catalog=Autolot; Data Source=(local)\\MSSQLSERVER2014";
            DataSet ds = new DataSet("Autolot");
            SqlDataAdapter dAdapt = new SqlDataAdapter("Select * From Inventory", cnStr);
            DataTableMapping curMap = dAdapt.TableMappings.Add("Inventory", "Current Inventory");
            curMap.ColumnMappings.Add("CarID", "ID of Car");
            curMap.ColumnMappings.Add("PetName", "Name of car");
            dAdapt.Fill(ds, "Inventory");
            PrintDataSet(ds);
            Console.ReadLine();
        }
        #region
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
            
            DataRow carRow = dt.NewRow();
            carRow["Make"] = "BMW";
            carRow["Color"] = "Black";
            carRow["PetName"] = "Hamlet";
            dt.Rows.Add(carRow);
            carRow = dt.NewRow();
            carRow[1] = "Renault";
            carRow[2] = "Duster";
            carRow[3] = "Black";
            dt.Rows.Add(carRow);
            dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };
            ds.Tables.Add(dt);
        }
        private static void ManipulateDataRowState()
        {
            DataTable temp = new DataTable("Temp");
            temp.Columns.Add(new DataColumn("TempColumn",typeof(int)));

            DataRow row =temp.NewRow();
            Console.WriteLine("After calling NewRow(): {0}",row.RowState);
            temp.Rows.Add(row);
            Console.WriteLine("After calling Rows.Add(): {0}", row.RowState);
            row[0] = 10;
            Console.WriteLine("After first assignment: {0}", row.RowState);

            row.AcceptChanges();
            Console.WriteLine("After calling AcceptChanges(): {0}", row.RowState);

            row[0] = 11;
            Console.WriteLine("After first assignment: {0}", row.RowState);

            temp.Rows[0].Delete();
            Console.WriteLine("After calling Delete: {0}", row.RowState);
        }
        static void PrintDataSet(DataSet ds)
        {
            Console.WriteLine("DataSet is named: {0}", ds.DataSetName);
            foreach (System.Collections.DictionaryEntry de in ds.ExtendedProperties)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }
            Console.WriteLine(ds.Tables.Count);
            foreach (DataTable dd in ds.Tables)
            {
                Console.WriteLine("=> {0} Table:", dd.TableName);
                for (int curCol = 0; curCol < dd.Columns.Count; curCol++)
                {
                    Console.Write(dd.Columns[curCol].ColumnName + "\t");
                }
                Console.WriteLine("\n------------------------------------------------");
                PrintTable(dd);
            }
        }
        static void PrintTable(DataTable dt)
        {
            DataTableReader dtr = dt.CreateDataReader();
            while (dtr.Read())
            {
                for (int i = 0; i < dtr.FieldCount; i++)
                {
                    Console.Write("{0} \t", dtr.GetValue(i).ToString().Trim());
                }
                Console.WriteLine();
            }
            dtr.Close();
        }
        
        static void SaveAndLoadXML(DataSet dts)
        {
            dts.WriteXml("docxml.xml");
            dts.WriteXmlSchema("docxsd.xsd");

            dts.Clear();
            dts.ReadXml("docxml.xml");
        }
        

        static void SaveAndLoadBinary(DataSet dts)
        {
            dts.RemotingFormat = SerializationFormat.Binary;
            FileStream fs = new FileStream("BinaryCar.bin", FileMode.Create);
            BinaryFormatter bfm = new BinaryFormatter(); 
            bfm.Serialize(fs, dts);
            fs.Close();

            dts.Clear();

            fs = new FileStream("BinaryCar.bin", FileMode.Open);
            DataSet ds = (DataSet)bfm.Deserialize(fs);
        }
        #endregion
    }
}