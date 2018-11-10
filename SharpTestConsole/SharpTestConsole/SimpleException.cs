using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Configuration;
using System.Data.Common;

namespace MyConnectionFactory
{
    enum DataProvider { SqlServer, OleDbc, Odbc, None}
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***Very simple connection factory***");
            string provString = ConfigurationManager.AppSettings["provider"];
            string cnString = ConfigurationManager.AppSettings["cnStr"];
            DbProviderFactory dbf = DbProviderFactories.GetFactory(provString);
            using (DbConnection cn = dbf.CreateConnection())
            {
                Console.WriteLine("Your connection object is a: {0}", cn.GetType().Name);
                cn.ConnectionString = cnString; 
                cn.Open();
                DbCommand cmd = dbf.CreateCommand();
                Console.WriteLine("Your command object is a: {0}", cmd.GetType().Name);
                cmd.Connection = cn;
                cmd.CommandText = "Select * From Inventory";

                using (DbDataReader dbr = cmd.ExecuteReader())
                {
                    Console.WriteLine("Your data reader object is a: {0}", dbr.GetType().Name);
                    Console.WriteLine("\n***Current Inventory***");
                    while (dbr.Read())
                        Console.WriteLine("-> Car {0} is a {1}", dbr["CarID"], dbr["Make"].ToString());
                }
            }

            Console.ReadLine();
        }
        static IDbConnection GetConnetction(DataProvider dp)
        {
            IDbConnection conn = null;
            switch (dp)
            {
                case DataProvider.SqlServer:
                    conn = new SqlConnection();
                    break;
                case DataProvider.OleDbc:
                    conn = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    conn = new OdbcConnection();
                    break;
            }
            return conn;
        }
    }
}