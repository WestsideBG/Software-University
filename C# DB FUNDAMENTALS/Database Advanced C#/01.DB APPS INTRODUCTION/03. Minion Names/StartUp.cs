namespace _03._Minion_Names
{
    using System;
    using System.Data.SqlClient;
    using _1._Initial_Setup;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(Configurations.ConnectionString);

            using (connection)
            {
                connection.Open();


                string villianNameQuery = "SELECT Name FROM Villains WHERE Id = @Id";
                SqlCommand command = new SqlCommand(villianNameQuery,connection);

                using (command)
                {
                    command.Parameters.AddWithValue("@Id", id);

                    string villianName = (string)command.ExecuteScalar();

                    if (villianName == null)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villianName}");

                    string minionsQuery =
                        "SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,m.Name, m.Age FROM MinionsVillains AS mv JOIN Minions As m ON mv.MinionId = m.Id WHERE mv.VillainId = @Id ORDER BY m.Name";

                    command = new SqlCommand(minionsQuery, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    using (reader)
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                        }


                        while (reader.Read())
                        {
                            int number = int.Parse(reader[0].ToString());
                            string minionName = (string)reader[1];
                            int minionAge = int.Parse(reader[2].ToString());

                            Console.WriteLine($"{number}. {minionName} {minionAge}");
                        }

                    }
                }
            }
        }
    }
}
