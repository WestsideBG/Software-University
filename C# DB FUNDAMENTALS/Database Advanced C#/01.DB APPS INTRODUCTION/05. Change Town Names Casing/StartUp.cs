namespace _05._Change_Town_Names_Casing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using _1._Initial_Setup;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string countryName = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
            {
                connection.Open();

                string updateTownsQuery =
                    "UPDATE Towns\r\n   SET Name = UPPER(Name)\r\n WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                using (SqlCommand command = new SqlCommand(updateTownsQuery, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("No town names were affected.");
                        return;
                    }


                    Console.WriteLine($"{rowsAffected} town names were affected.");
                }

                string getAffectedRowsSql =
                    "  SELECT t.Name \r\n   FROM Towns as t\r\n   JOIN Countries AS c ON c.Id = t.CountryCode\r\n  WHERE c.Name = @countryName";


                using (SqlCommand command = new SqlCommand(getAffectedRowsSql, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    List<string> list = new List<string>();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add((string)reader[0]);
                    }

                    Console.WriteLine(string.Join(", ", list));

                }

            }


        }
    }
}
