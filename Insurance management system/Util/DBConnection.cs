using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Insurance_management_system.Util
{
    static class DBConnection
    {
        private static SqlConnection connection = null;

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ims"].ConnectionString;

                connection = new SqlConnection(connectionString);
            }

            return connection;
        }
    }

}

