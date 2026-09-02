using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ONESTOPEVENTS
{
    internal static class Database
    {
        internal const string ConnectionStringName = "OneStopEvents";

        internal static SqlConnection CreateConnection()
        {
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[ConnectionStringName];

            if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
            {
                throw new ConfigurationErrorsException(
                    "The OneStopEvents connection string is missing from App.config.");
            }

            return new SqlConnection(settings.ConnectionString);
        }

        internal static DataTable Query(
            string commandText,
            Action<SqlParameterCollection> configureParameters = null)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(commandText, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                configureParameters?.Invoke(command.Parameters);
                DataTable result = new DataTable();
                connection.Open();
                adapter.Fill(result);
                return result;
            }
        }

        internal static int Execute(
            string commandText,
            Action<SqlParameterCollection> configureParameters = null)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(commandText, connection))
            {
                configureParameters?.Invoke(command.Parameters);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        internal static int ExecuteStoredProcedure(
            string procedureName,
            Action<SqlParameterCollection> configureParameters = null)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                configureParameters?.Invoke(command.Parameters);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        internal static object Scalar(
            string commandText,
            Action<SqlParameterCollection> configureParameters = null)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(commandText, connection))
            {
                configureParameters?.Invoke(command.Parameters);
                connection.Open();
                return command.ExecuteScalar();
            }
        }

        internal static void AddInt(SqlParameterCollection parameters, string name, int value)
        {
            parameters.Add(name, SqlDbType.Int).Value = value;
        }

        internal static void AddVarChar(
            SqlParameterCollection parameters,
            string name,
            int length,
            string value)
        {
            parameters.Add(name, SqlDbType.VarChar, length).Value = value;
        }

        internal static void AddMoney(SqlParameterCollection parameters, string name, decimal value)
        {
            parameters.Add(name, SqlDbType.Money).Value = value;
        }

        internal static void AddDate(SqlParameterCollection parameters, string name, DateTime value)
        {
            parameters.Add(name, SqlDbType.Date).Value = value.Date;
        }

        internal static void AddChar(
            SqlParameterCollection parameters,
            string name,
            char value)
        {
            parameters.Add(name, SqlDbType.Char, 1).Value = value;
        }
    }
}
