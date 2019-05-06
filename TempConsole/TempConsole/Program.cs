using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TempConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Order ord = null;

            StoreConnectedLayer stc = new StoreConnectedLayer();
            try
            {
                //SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["StoreConnLayer"].ConnectionString);
                //sqlConnection.Open();

                //SqlCommand sqlCommand = new SqlCommand($"drop database TestDb", sqlConnection);
                //sqlCommand.ExecuteNonQuery();
                ord = stc.GetOrderWithQueueParallel("sdfsdf", "sdfsdf", 6);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
        }
    }
}