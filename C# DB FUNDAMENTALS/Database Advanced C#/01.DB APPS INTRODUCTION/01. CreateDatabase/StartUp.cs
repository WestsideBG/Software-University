using System;
using System.Data.SqlClient;

namespace _01._CreateDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string createDatabaseCMD = "CREATE DATABASE MinionsDB";

            SqlConnection connection = new SqlConnection(Configurations.ConnectionString);

            using (connection)
            {
                connection.Open();
                NonQueryCommandExec(createDatabaseCMD, connection);
            }
        }
        private static void NonQueryCommandExec(string sqlCmd, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlCmd, connection);

            using (command)
            {
                command.ExecuteNonQuery();
            }
        }

    }
}
