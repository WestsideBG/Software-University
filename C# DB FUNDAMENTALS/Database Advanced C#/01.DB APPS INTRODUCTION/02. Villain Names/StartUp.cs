namespace _02._Villain_Names
{
    using System;
    using System.Data.SqlClient;
    using _1._Initial_Setup;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string sqlCmd =
                "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  \r\n    FROM Villains AS v \r\n    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId \r\nGROUP BY v.Id, v.Name \r\n  HAVING COUNT(mv.VillainId) > 3 \r\nORDER BY COUNT(mv.VillainId)\r\n";
            SqlConnection connection = new SqlConnection(Configurations.ConnectionString);

            using (connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlCmd,connection);

                using (command)
                {
                    SqlDataReader reader = command.ExecuteReader();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} - {reader[1]}");
                        }
                    }     
                }
            }
        }
    }
}
