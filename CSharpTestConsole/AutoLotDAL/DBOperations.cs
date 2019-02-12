using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace AutoLotDAL
{
    public class DBOperations
    {
        public string connectionString { get; set; }
        private SqlConnection sqlCon = null;
         

        public DBOperations():
            this(@"Data Source=DIMA\SQLEXPRESS;Initial Catalog=AutoLot;Integrated Security=True")
        {

        }

        public DBOperations(string constr)
        {
            connectionString = constr;
        }

        private void OpenConnection()
        {
            sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
        }

        private void CloseConnection()
        {
            if(sqlCon?.State!=ConnectionState .Closed)
                sqlCon?.Close();
        }

        public List<Car> GetAllCars()
        {
            OpenConnection();
            List<Car> inventory = new List<Car>();

            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * From Inventory";
            //command.CommandType = CommandType.Text;
            command.Connection = sqlCon;

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
                inventory.Add(new Car
                {
                    CarID = (int)reader["CarID"],
                    Color = (string)reader["Color"],
                    Make = (string)reader["Make"],
                    PetName = (string)reader["PetName"]
                });
            CloseConnection();

            return inventory;
        }

        public Car GetCar(int id)
        {
            OpenConnection();
            Car cr = null;
            SqlCommand command = new SqlCommand();
            command.CommandText = $"Select * From Inventory Where CarID = {id}";
            command.Connection = sqlCon;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cr = new Car
                {
                    CarID = (int)reader["CarID"],
                    Make = (string)reader["Make"],
                    Color = (string)reader["Color"],
                    PetName = (string)reader["PetName"]
                };
            }

            CloseConnection();
            return cr;
        }

        public void InsertAuto(int carId, string make, string color, string petName)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = $"Insert Into Inventory (CarID, Make, Color, PetName)"+
                $"Values ({carId}, '{make}', '{color}', '{petName}')";
            OpenConnection();
            command.Connection = sqlCon;

            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void InsertAuto(Car cr)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Insert Into Inventory ('Make', 'Color', 'PetName')" +
                $" Values('{cr.Make}', '{cr.Color}', '{cr.PetName}')";
            OpenConnection();
            command.Connection = sqlCon;

            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void DeleteCar(int id)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = $"Delete From Inventory Where CarID='{id}'";
            OpenConnection();
            command.Connection = sqlCon;
            try
            {
                command.ExecuteNonQuery();
            }catch(SqlException ex)
            {
                Exception exception = new Exception("Sorry the car is ordered", ex);
                throw ex;
            }
        }

        public void UpdateCar(int id, string newPetName)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = $"Update Inventory Set PetName='{newPetName}'";
            command.Connection = sqlCon;
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void InsertAuto(Car cr, bool IsSqlParameterEnabled)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlCon;
            command.CommandText = "Insert Into Inventory(CarID, Make, Color, PetName)" +
                "Values(@CarID, @Make, @Color, @PetName)";
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Make";
            parameter.Value = cr.Make;
            parameter.SqlDbType = SqlDbType.Char;
            parameter.Size = 20;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Color";
            parameter.Value = cr.Color;
            parameter.SqlDbType = SqlDbType.Char;
            parameter.Size = 20;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@PetName";
            parameter.Value = cr.PetName;
            parameter.SqlDbType = SqlDbType.Char;
            parameter.Size = 20;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@CarID";
            parameter.Value = cr.CarID;
            parameter.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();
            CloseConnection();
        }

        public string LookUpPetName(int carid)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlCon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetPetName";

            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@carID",
                SqlDbType = SqlDbType.Int,
                Value = carid,
                Direction = ParameterDirection.Input
            };
            command.Parameters.Add(parameter);

            parameter = new SqlParameter
            {
                ParameterName = "@petName",
                SqlDbType = SqlDbType.Char,
                Size = 20,
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();

            string CarPetName = (string)command.Parameters["@petName"].Value;
            CloseConnection();

            return CarPetName;
        }
    }
}
