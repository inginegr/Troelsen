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
            bool throwEx = true;
            string userAnswer = string.Empty;
            Console.Write("Do you want to throw an exception (Y or N): ");
            userAnswer = Console.ReadLine();
            if (userAnswer.ToLower() == "n")
                throwEx = false;
            InventoryDAL dal = new InventoryDAL();
            dal.OpenConnection(@"Data Source=DIMA-PC\MSSQLSERVER2014;Integrated Security = SSPI; Initial Catalog=AutoLot");
            dal.ProcessCreditRisk(throwEx, 333);
            Console.WriteLine("Check CreditRisk table for results");
            Console.ReadLine();
        }
    }
}