using Carpenter_v1.service;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Carpenter_v1
{
    class DatabaseManager
    {
        private SqlConnection connection;
        private SqlDataReader dataReader;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;
        private string connectionString ;
        private static DatabaseManager instance;
        StringBuilder errorMessages = new StringBuilder();

        private DataSet dataSet;

        private DatabaseManager() {
            connectionString = constants.enums.DatabaseSqlCodeExtension.getConnectionString();
        }
        public static DatabaseManager getInstance() => (instance == null) ? (new DatabaseManager()) : instance;

        private void garbarageCollector()
        {
            dataAdapter.Dispose();
            command.Dispose();
            connection.Close();
        }

        public bool connectDatabase()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                ShowException.ShowSqlException(ex);              
            }
            return false;
        }

        public DataSet getData(String sql, String tableName)
        {
            if (connectDatabase())
            {
                try
                {
                    dataAdapter = new SqlDataAdapter(sql, connection);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, tableName);
                    connection.Close();
                    dataSet.Dispose();
                    return dataSet;
                }
                catch (SqlException ex)
                {
                    ShowException.ShowSqlException(ex);
                }
            }
            return null;
        }

        public bool insertData(String sql)
        {
            if (connectDatabase())
            {
                try
                {
                    command = new SqlCommand(sql, connection);
                    dataAdapter = new SqlDataAdapter();
                    dataAdapter.InsertCommand = new SqlCommand(sql, connection);
                    dataAdapter.InsertCommand.ExecuteNonQuery();
                    garbarageCollector();
                    return true;
                }
                catch (SqlException ex)
                {
                    ShowException.ShowSqlException(ex);
                    garbarageCollector();
                }
            }
            return false;
        }


        public bool updateData(String sql)
        {
            if (connectDatabase())
            {
                try
                {
                    command = new SqlCommand(sql, connection);
                    dataAdapter = new SqlDataAdapter();
                    dataAdapter.UpdateCommand = new SqlCommand(sql, connection);
                    dataAdapter.UpdateCommand.ExecuteNonQuery();
                    garbarageCollector();
                    return true;
                }
                catch (SqlException ex)
                {
                    ShowException.ShowSqlException(ex);
                    garbarageCollector();
                }
            }
            return false;
        }

        public bool deleteData(String sql)
        {
            if (connectDatabase())
            {
                try
                {
                    command = new SqlCommand(sql, connection);
                    dataAdapter = new SqlDataAdapter();
                    dataAdapter.DeleteCommand = new SqlCommand(sql, connection);
                    dataAdapter.DeleteCommand.ExecuteNonQuery();
                    garbarageCollector();
                    return true;
                }
                catch (SqlException ex)
                {
                    ShowException.ShowSqlException(ex);
                    garbarageCollector();

                }
            }
            return false;
        }

    }
}
