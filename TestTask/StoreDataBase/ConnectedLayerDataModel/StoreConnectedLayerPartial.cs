using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using StoreDataBase.EntityDataModel;

namespace StoreDataBase.ConnectedLayerDataModel
{
    public partial class StoreConnectedLayer
    {
        // Connection string to DB
        private string ConnectionStringStoreDB { get; set; }

        private string DataBaseName { get; set; }

        //Connect to DB
        private SqlConnection ConnectToDataBase(string connectionStringParam)
        {
            SqlConnection returnConnection = null;
            try
            {
                returnConnection = new SqlConnection(connectionStringParam);
                returnConnection.Open();
            }
            catch (Exception ex)
            {
                LogToFile(ex.Message);
            }

            return returnConnection;
        }

        // Close DB connection
        private bool CloseDataBaseConnection(SqlConnection connectionParam)
        {
            bool retRezult = true;
            try
            {
                connectionParam?.Close();
            }
            catch (Exception ex)
            {
                LogToFile(ex.Message);
                retRezult = false;
            }
            return retRezult;
        }

        //Remove DB
        private bool RemoveStoreDB(string nameDataBase, SqlConnection connectionParam)
        {
            bool retRezult = true;
            try
            {
                SqlCommand sqlCommand = new SqlCommand($"drop database {nameDataBase};", connectionParam);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                LogToFile(ex.Message);

            }
            catch (Exception ex)
            {
                LogToFile(ex.Message);
                connectionParam.Close();
                retRezult = false;
            }
            return retRezult;
        }

        // Create Store Data Base
        private bool CreateStoreDB(string nameDataBase, SqlConnection connectionParam)
        {
            DataBaseName = nameDataBase;
            bool retRezult = true;
            try
            {
                SqlCommand command = new SqlCommand($"create database {nameDataBase};", connectionParam);
                command.ExecuteNonQuery();
                connectionParam.ChangeDatabase(nameDataBase);
            }
            catch (Exception ex)
            {
                LogToFile(ex.Message);
                retRezult = false;
            }
            return retRezult;
        }

        //Creates some table inside Data Base
        private bool CreateTableInDB(string TableName, SqlConnection connectionParam, params TableDataBase[] tableDataBasesParams)
        {
            bool retRezult = true;
            string commandString = $"create table {TableName} (";

            // Form string with command for db query
            for (int i = 0; i < tableDataBasesParams.Length; i++)
            {
                commandString += $"{tableDataBasesParams[i].NameColumn} {tableDataBasesParams[i].ColumnType} {tableDataBasesParams[i].CreateParams}";
                if (i != (tableDataBasesParams.Length - 1))
                    commandString += ", ";
                else
                    commandString += ")";
            }

            // Make query to DB
            try
            {
                SqlCommand command = new SqlCommand(commandString, connectionParam);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogToFile(ex.Message);
                retRezult = false;
            }

            return retRezult;
        }

        // Insert data in some DB table
        private bool InsertIntoDBTable(string DBTableName, SqlConnection sqlConnectionParam = null, params TableDataBase[] tableDataBasesParams)
        {
            bool retRezult = true;

            string SQL_Query = $"insert into {DBTableName} (";

            //Form query string
            for (int i = 0; i < tableDataBasesParams.Length; i++)
            {
                SQL_Query += $"{tableDataBasesParams[i].NameColumn}";
                if (i == (tableDataBasesParams.Length - 1))
                    SQL_Query += ") ";
                else
                    SQL_Query += ", ";
            }

            SQL_Query += "values (";

            for (int i = 0; i < tableDataBasesParams.Length; i++)
            {
                SQL_Query += $"'{tableDataBasesParams[i].ParamColumn}'";
                if (i == (tableDataBasesParams.Length - 1))
                    SQL_Query += ") ";
                else
                    SQL_Query += ", ";
            }
            SQL_Query += ";";

            //Execute SQL command
            try
            {
                if (sqlConnectionParam == null)
                    sqlConnectionParam = ConnectToDataBase(ConnectionStringStoreDB);

                SqlCommand sqlCommand = new SqlCommand(SQL_Query, sqlConnectionParam);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogToFile(ex.Message);
                retRezult = false;
            }
            finally
            {
                //sqlConnectionParam?.Close();
            }

            return retRezult;
        }

        // Update data in some DB table
        private bool UpdateDataInDB(string DBTableName, string ItemIDName, int ItemIdValue, string ItemChangeName, int NewValue, SqlConnection sqlConnectionParam = null)
        {
            bool retRezult = true;

            string SQL_Command = $"update {DBTableName} set {ItemChangeName}={NewValue} where {ItemIDName}={ItemIdValue}";

            //Execute SQL command
            try
            {
                if (sqlConnectionParam == null)
                    sqlConnectionParam = new SqlConnection(ConnectionStringStoreDB);

                SqlCommand sqlCommand = new SqlCommand(SQL_Command, sqlConnectionParam);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogToFile(ex.Message);
                retRezult = false;
            }
            finally
            {

            }

            return retRezult;
        }

        // Select data from DB
        private List<string> SelectParamFromDB(SqlConnection sqlConnectionParam=null, string ParamName="GoodsRemain", 
            string TableName="Goods", string IDName="GoodsID", string IDValue="1")
        {
            List<string> retStringCollection = new List<string>();

            if (sqlConnectionParam == null)
                sqlConnectionParam = new SqlConnection(ConnectionStringStoreDB);

            // Form SQL command
            string SQL_Command = $"select {ParamName} from {TableName} where {IDName}={IDValue}";
            SqlDataReader sqlDataReader = null;

            //Select data from DB
            try
            {
                SqlCommand command = new SqlCommand(SQL_Command, sqlConnectionParam);

                sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    retStringCollection.Add(sqlDataReader[$"{ParamName}"].ToString());
                }
            }
            catch (Exception ex)
            {
                LogToFile(ex.Message);
                retStringCollection.Clear();
            }
            finally
            {
                sqlDataReader.Close();
            }

            return retStringCollection;
        }

        // Initialyze Data Base for Store
        private bool InitialyzeDBForStore()
        {
            bool retRezult = true;

            // Make connection to DB
            SqlConnection sqlConnection = ConnectToDataBase(ConnectionStringStoreDB);

            // Remove all data from DB if any
            retRezult = RemoveStoreDB("TestDB", sqlConnection);

            //Create Store Data Base
            retRezult = CreateStoreDB("TestDB", sqlConnection);

            //Create table with Goods
            retRezult = CreateTableInDB("Goods", sqlConnection,
                new TableDataBase { NameColumn = "GoodsID", ColumnType = "int", CreateParams = "not null primary key identity" },
                new TableDataBase { NameColumn = "GoodsName", ColumnType = "nvarchar(50)", CreateParams = "not null" },
                new TableDataBase { NameColumn = "GoodsRemain", ColumnType = "int", CreateParams = "not null" });

            // Create table with buyers
            retRezult = CreateTableInDB("Buyers", sqlConnection,
                new TableDataBase { NameColumn = "BuyerID", ColumnType = "int", CreateParams = "not null primary key identity" },
                new TableDataBase { NameColumn = "BuyerName", ColumnType = "nvarchar(50)", CreateParams = "not null" },
                new TableDataBase { NameColumn = "BuyerGoods", ColumnType = "nvarchar(50)", CreateParams = "not null" },
                new TableDataBase { NameColumn = "GoodsNumber", ColumnType = "int", CreateParams = "not null" });

            // Fill "Goods" table
            retRezult = InsertIntoDBTable("Goods", sqlConnection,
                new TableDataBase { NameColumn = "GoodsName", ParamColumn = "SuperGoods" },
                new TableDataBase { NameColumn = "GoodsRemain", ParamColumn = "100" });

            CloseDataBaseConnection(sqlConnection);
            numOrders = 100;

            return retRezult;
        }

        public StoreConnectedLayer()
        {
            ConnectionStringStoreDB = ConfigurationManager.ConnectionStrings["StoreConnLayer"].ConnectionString;
            /*if (!*/
            InitialyzeDBForStore();//)
                                   //throw new Exception("Data Base not initialized");
            numOrders = 100;

            //Инициализируем блокирвки
            BlockQueue = new object();
            BlockDB = new object();
            BlockNumOrder = new object();

            orderCollectionToServe = new Queue<Order>();
            orderCollectionServed = new List<Order>();
        }
    }
}
