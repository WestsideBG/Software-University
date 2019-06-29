namespace _07._Print_All_Minion_Names
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using _1._Initial_Setup;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configurations.ConnectionString))
            {
                connection.Open();
                List<string> minionNames = new List<string>();
                string sqlQuery = "SELECT Name FROM Minions";

                using (SqlCommand command = new SqlCommand(sqlQuery,connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            minionNames.Add((string)reader[0]);
                        }
                    }
                }

                for (int i = 0; i < minionNames.Count / 2; i++)
                {
                    Console.WriteLine(minionNames[i]);
                    Console.WriteLine(minionNames[minionNames.Count - 1 - i]);
                }

                if (minionNames.Count % 2 != 0)
                {
                    Console.WriteLine(minionNames[minionNames.Count / 2]);
                }
            }
        }
    }
}
