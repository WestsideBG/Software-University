namespace _06.Remove_Villain
{
    using System;
    using System.Data.SqlClient;
    using _1._Initial_Setup;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
            {
                connection.Open();

                string villainName = GetVillainNameById(connection, villainId);

                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                int affectedRows = DeleteMinionsVillainsById(connection, villainId);

                DeleteVillainById(connection, villainId);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{affectedRows} minions were released.");

            }
        }

        private static void DeleteVillainById(SqlConnection connection, int villainId)
        {
            string deleteQuery = "DELETE FROM Villains\r\n      WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(deleteQuery,connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.ExecuteNonQuery();
            }
        }

        private static int DeleteMinionsVillainsById(SqlConnection connection, int villainId)
        {
            string deleteQuery = "DELETE FROM MinionsVillains \r\n      WHERE VillainId = @villainId";
            using (SqlCommand command = new SqlCommand(deleteQuery,connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                return command.ExecuteNonQuery();
            }
        }

        private static string GetVillainNameById(SqlConnection connection, int villainId)
        {
            string getNameQuery = "SELECT Name FROM Villains WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(getNameQuery,connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                return (string)command.ExecuteScalar();
            }
        }
    }
}
