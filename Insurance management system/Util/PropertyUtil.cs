using System;
using System.Data.SqlClient;
using System.IO;

namespace InsuranceManagementSystem.util
{
    class DBPropertyUtil
    {
        public static string GetConnectionString(string propertyFileName)
        {
            try
            {

                var properties = File.ReadAllLines(propertyFileName);
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                foreach (var property in properties)
                {
                    var keyValue = property.Split('=');
                    if (keyValue.Length == 2)
                    {
                        builder[keyValue[0]] = keyValue[1];
                    }
                }

                return builder.ConnectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading property file: {ex.Message}");
                return null;
            }
        }
    }

    class DBConnUtil
    {
        public static SqlConnection GetConnection(string connectionString)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Database connection established.");
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error establishing database connection: {ex.Message}");
                return null;
            }
        }
    }
}
