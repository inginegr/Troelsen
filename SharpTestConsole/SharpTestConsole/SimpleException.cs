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
    class Program
    {
        static void Main()
        {
            Console.WriteLine("*** The AutoLot Console UI ***");

            string cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            bool userDone = false;
            string userCommand = "";
            InventoryDAL invDal = new InventoryDAL();
            invDal.OpenConnection(cnStr);

            try
            {
                ShowInstructions();
                do
                {
                    Console.Write("\n Please enter your command: ");
                    userCommand = Console.ReadLine();
                    Console.WriteLine();
                    switch (userCommand.ToUpper())
                    {
                        case "I":
                            InsertNewCar(invDal);
                            break;
                        case "U":
                            UpdateCarPetName(invDal);
                            break;
                        case "D":
                            DeleteCar(invDal);
                            break;
                        case "L":
                            ListInventory(invDal);
                            break;
                        case "S":
                            ShowInstructions();
                            break;
                        case "P":
                            LookUpPetName(invDal);
                            break;
                        case "Q":
                            userDone = true;
                            break; 
                        default:
                            Console.WriteLine("Bad Data! Try again");
                            break;
                    }
                } while (!userDone);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                invDal.CloseConnection();
            }
            Console.ReadLine();
        }
        private static void ShowInstructions()
        {
            Console.WriteLine("I: Inserts a new car.");
            Console.WriteLine("U: Updates an existing car.");
            Console.WriteLine("D: Deletes an existing car.");
            Console.WriteLine("L: Lists current inventory.");
            Console.WriteLine("S: Shows these instructions.");
            Console.WriteLine("P: Looks up pet name.");
            Console.WriteLine("Q: Quits program.");
        }
        private static void ListInventory(InventoryDAL invDAL)
        {
            DataTable dt = invDAL.GetAllInventoryAsDatatable();
            DisplayTable(dt);
        }
        private static void DisplayTable(DataTable dt)
        {
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Console.WriteLine(dt.Columns[curCol].ColumnName + "\t");
            }
            Console.WriteLine("\n--------------------------------------");
            for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
                }
            }
        }
        private static void DeleteCar(InventoryDAL invDAL)
        {
            Console.WriteLine("Enter the number of car, please");
            int id = int.Parse(Console.ReadLine());

            try
            {
                invDAL.DeleteCar(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void InsertNewCar(InventoryDAL invDAL)
        {
            int newCarId;
            string newCarColor, newCarMake, newCarPetName;
            
            Console.WriteLine("Enter Car ID: ");
            newCarId = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter Car Color: ");
            newCarColor = Console.ReadLine();
            
            Console.WriteLine("Enter Car Make: ");
            newCarMake = Console.ReadLine();

            Console.WriteLine("Enter Pet Name: ");
            newCarPetName = Console.ReadLine();

            invDAL.InsertAuto(newCarId, newCarColor, newCarMake, newCarPetName);
        }
        private static void UpdateCarPetName(InventoryDAL invDAL)
        {
            int carID;
            string newCarPeName;

            Console.WriteLine("Enter Car ID: ");
            carID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new pet namespace: ");
            newCarPeName = Console.ReadLine();

            invDAL.UpdateCarPetName(carID, newCarPeName);
        }
        private static void LookUpPetName(InventoryDAL invDAL)
        {
            Console.WriteLine("Enter ID of Car to look up: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("PetName of {0} is {1}", id, invDAL.LookUpPetName(id).TrimEnd());
        }
    }
}