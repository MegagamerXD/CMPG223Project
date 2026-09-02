using System.Configuration;
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
    }
}
