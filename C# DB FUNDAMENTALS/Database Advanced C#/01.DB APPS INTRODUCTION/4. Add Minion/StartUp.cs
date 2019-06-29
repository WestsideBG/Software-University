namespace _4._Add_Minion
{
    using System;
    using System.Data.SqlClient;
    using _1._Initial_Setup;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] minionArgs = Console.ReadLine().Split();
            string[] villainArgs = Console.ReadLine().Split();

            string minionName = minionArgs[1];
            int minionAge = int.Parse(minionArgs[2]);
            string minionTown = minionArgs[3];

            string villainName = villainArgs[1];

            using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
            {
                connection.Open();

                int? townId = GetTownId(minionTown, connection);
                if (townId == null)
                {
                    AddTown(connection, minionTown);
                }

                townId = GetTownId(minionTown, connection);

                int? villainId = GetVillainId(connection, villainName);

                if (villainId == null)
                {
                    AddVillain(connection, villainName);
                }

                villainId = GetVillainId(connection, villainName);

                AddMinion(connection, minionName, minionAge, townId);

                int minionId = GetMinionId(connection, minionName);

                AddMinionVillainMappingTable(connection, villainId, minionId,villainName,minionName);

            }
        }

        private static void AddMinionVillainMappingTable(SqlConnection connection, int? villainId, int minionId, string villainName, string minionName)
        {
            string sqlQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId,@villainId)";

            using (SqlCommand command = new SqlCommand(sqlQuery,connection))
            {
                command.Parameters.AddWithValue("@minionId", minionId);
                command.Parameters.AddWithValue("@villainId", villainId);
                command.ExecuteNonQuery();
            }

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static int GetMinionId(SqlConnection connection, string minionName)
        {
            string getIdSql = "SELECT Id FROM Minions WHERE Name = @Name";
            using (SqlCommand command = new SqlCommand(getIdSql,connection))
            {
                command.Parameters.AddWithValue("@Name", minionName);
                return (int) command.ExecuteScalar();
            }
        }

        private static void AddMinion(SqlConnection connection, string minionName, int minionAge, int? townId)
        {
            string insertMinionSql = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            using (SqlCommand command = new SqlCommand(insertMinionSql, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                command.Parameters.AddWithValue("@age", minionAge);
                command.Parameters.AddWithValue("@townId", townId);

                command.ExecuteNonQuery();
            }
        }

        private static void AddVillain(SqlConnection connection, string villainName)
        {
            string insertVillainSql = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

            using (SqlCommand command = new SqlCommand(insertVillainSql, connection))
            {
                command.Parameters.AddWithValue("@villainName", villainName);
                command.ExecuteNonQuery();
            }

            Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static int? GetVillainId(SqlConnection connection, string villainName)
        {
            string getVillainIdSql = "SELECT Id FROM Villains WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(getVillainIdSql, connection))
            {
                command.Parameters.AddWithValue("@Name", villainName);
                return (int?)command.ExecuteScalar();
            }

        }

        private static int? GetTownId(string minionTown, SqlConnection connection)
        {
            string sqlQuery = "SELECT Id FROM Towns WHERE Name = @townName";
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.Parameters.AddWithValue("@townName", minionTown);

                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddTown(SqlConnection connection, string minionTown)
        {
            string insertTownQuery = "INSERT INTO Towns (Name) VALUES (@townName)";

            using (SqlCommand command = new SqlCommand(insertTownQuery, connection))
            {
                command.Parameters.AddWithValue("@townName", minionTown);
                command.ExecuteNonQuery();
            }

            Console.WriteLine($"Town {minionTown} was added to the database.");
        }
    }
}
