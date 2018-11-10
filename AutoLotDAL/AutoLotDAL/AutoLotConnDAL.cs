using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotConnectedLayer
{
    public class InventoryDAL
    {
        // Этот член будет использоваться всеми методами.
        private SqlConnection sqlCn = null;
        public void OpenConnection(string connectionstring)
        {
            sqlCn = new SqlConnection();
            sqlCn.ConnectionString = connectionstring;
            sqlCn.Open();
        }
        public void CloseConnection()
        {
            sqlCn.Close();
        }
        public void InsertAuto(int id, string color, string make, string petName)
        {
            // Сформировать SQL-оператор.
            string sql = string.Format("Insert Into Inventory" +
            "(CarlD, Make, Color, PetName) Values" +
            "('{0}', '{1}', '{2}', '{3}')", id, make, color, petName);
            // Выполнить SQL-оператор с применением нашего подключения.
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void InsertAuto(NewCar car)
        {
            // Сформировать SQL-оператор.
            string sql = string.Format("Insert Into Inventory" +
            "(CarID, Make, Color, PetName) Values" +
            "(’{0}', '{1}', '{2}', '{3}')", car.CarID, car.Make, car.Color, car.PetName);
            // Выполнить SQL-оператор с применением нашего подключения. 
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteCar(int id)
        {
            // Получить идентификатор удаляемого автомобиля, затем выполнить удаление.
            string sql = string.Format("Delete from Inventory where CarID = '{0}'", id);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Sorry! That car is on order!", ex);
                    throw error;
                }
            }
        }
        public void UpdateCarPetName(int id, string newPetName)
        {
            string sql = string.Format("Update Inventory Set PetName = '{0}' Where CarID = '{1}'", newPetName, id);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public List<NewCar> GetAllInventoryAsList()
        {
            List<NewCar> inv = new List<NewCar>();
            string sql = "Select * From Inventory";
            using (SqlCommand scmd = new SqlCommand(sql, this.sqlCn))
            {
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    inv.Add(new NewCar
                    {

                        CarID = (int)sdr["CarID"],
                        Color = (string)sdr["Color"],
                        Make = (string)sdr["Make"],
                        PetName = (string)sdr["PetName"]
                    });
                }
                sdr.Close();
            }
            return inv;
        }
        public DataTable GetAllInventoryAsDatatable()
        {
            DataTable inv = new DataTable();
            string sql = "Select * From Inventory";
            using (SqlCommand scmd = new SqlCommand(sql, this.sqlCn))
            {
                SqlDataReader sdr = scmd.ExecuteReader();
                inv.Load(sdr);
                sdr.Close();
            }
            return inv;
        }
        //public void InsertAuto(int id, string color, string make, string petName)
        //{
        //    // Обратите внимание на "заполнители" в SQL-запросе.
        //    string sql = string.Format("Select * From Inventory (CarID, Make, Color, PetName) Values (@CarID, @Make, @Color, @PetName)");

        //    using (SqlCommand scmd = new SqlCommand(sql, this.sqlCn))
        //    {
        //        SqlParameter param = new SqlParameter();
        //        param.ParameterName = "@CarID";
        //        param.Value = id;
        //        param.SqlDbType = SqlDbType.Int;
        //        scmd.Parameters.Add(param);

        //        param = new SqlParameter();
        //        param.ParameterName = "@Make";
        //        param.Value = make;
        //        param.SqlDbType = SqlDbType.Char;
        //        param.Size = 10;
        //        scmd.Parameters.Add(param);

        //        param = new SqlParameter();
        //        param.ParameterName = "@Color";
        //        param.Value = color;
        //        param.SqlDbType = SqlDbType.Char;
        //        param.Size = 10;
        //        scmd.Parameters.Add(param);

        //        param = new SqlParameter();
        //        param.ParameterName = "@PetName";
        //        param.Value = petName;
        //        param.SqlDbType = SqlDbType.Char;
        //        param.Size = 10;
        //        scmd.Parameters.Add(param);

        //        scmd.ExecuteNonQuery();
        //    }
        //}
        public string LookUpPetName(int carID)
        {
            string carPetName = string.Empty;
            using (SqlCommand scmd = new SqlCommand("GetPetName", this.sqlCn))
            {
                scmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pr = new SqlParameter();
                pr.ParameterName = "@carID";
                pr.SqlDbType = SqlDbType.Int;
                pr.Value = carID;

                pr.Direction = ParameterDirection.Input;
                scmd.Parameters.Add(pr);

                pr = new SqlParameter();
                pr.ParameterName = "@petName";
                pr.SqlDbType = SqlDbType.Char;
                pr.Size = 10;
                pr.Direction = ParameterDirection.Output;

                scmd.ExecuteNonQuery();
                carPetName = (string)scmd.Parameters["@petName"].Value;
            }
            return carPetName;
        }
    }
    public class NewCar
    {
        public int CarID { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string PetName { get; set; }
    }
}
