using System;
using System.Data.SqlClient;
using _1._Initial_Setup;

namespace _09._Increase_Age_Stored_Procedure
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
            {
                connection.Open();
                string sqlQuery = "EXEC usp_GetOlder @id";

                using (SqlCommand command = new SqlCommand(sqlQuery,connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        string name = reader[0].ToString();
                        int age = (int) reader[1];

                        Console.WriteLine($"{name} - {age} years old");
                    }
                }
            }


        }
    }
}
