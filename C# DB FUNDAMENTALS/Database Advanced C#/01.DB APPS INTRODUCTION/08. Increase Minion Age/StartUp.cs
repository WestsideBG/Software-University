namespace _08._Increase_Minion_Age
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using _1._Initial_Setup;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
            {
                connection.Open();

                IncreaseMinionsAgeById(ids, connection);

                PrintMinionsNameAndAge(connection);
            }
        }

        private static void PrintMinionsNameAndAge(SqlConnection connection)
        {
            string sqlQuery = "SELECT Name, Age FROM Minions";

            using (SqlCommand command = new SqlCommand(sqlQuery,connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = (string)reader[0];
                        int age = (int)reader[1];
                        Console.WriteLine($"{name.Trim()} {age}");
                    }
                }

            }
        }

        private static void IncreaseMinionsAgeById(int[] ids, SqlConnection connection)
        {
            string sqlQuery =
                                "UPDATE Minions\r\n   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1\r\n WHERE Id = @Id";

            for (int i = 0; i < ids.Length; i++)
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", ids[i]);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
