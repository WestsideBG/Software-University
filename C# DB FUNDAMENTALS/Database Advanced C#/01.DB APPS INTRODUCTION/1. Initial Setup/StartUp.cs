namespace _1._Initial_Setup
{
    using System.Data.SqlClient;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] createTablesCMD = new string[6];
            FillTablesCommands(createTablesCMD);

            string[] insertInTablesCMD = new string[6];

            FillInsertStatemants(insertInTablesCMD);

            SqlConnection connection = new SqlConnection(Configurations.ConnectionString);

            using (connection)
            {
                connection.Open();
                foreach (var cmd in createTablesCMD)
                {
                    NonQueryCommandExec(cmd, connection);
                }

                foreach (var cmd in insertInTablesCMD)
                {
                    NonQueryCommandExec(cmd,connection);
                }

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

        private static void FillInsertStatemants(string[] insertInTablesCMD)
        {
            insertInTablesCMD[0] = "INSERT INTO Countries ([Name]) VALUES (\'Bulgaria\'),(\'England\'),(\'Cyprus\'),(\'Germany\'),(\'Norway\')";
            insertInTablesCMD[1] = "INSERT INTO Towns ([Name], CountryCode) VALUES (\'Plovdiv\', 1),(\'Varna\', 1),(\'Burgas\', 1),(\'Sofia\', 1),(\'London\', 2),(\'Southampton\', 2),(\'Bath\', 2),(\'Liverpool\', 2),(\'Berlin\', 3),(\'Frankfurt\', 3),(\'Oslo\', 4)";
            insertInTablesCMD[2] = "INSERT INTO Minions (Name,Age, TownId) VALUES(\'Bob\', 42, 3),(\'Kevin\', 1, 1),(\'Bob \', 32, 6),(\'Simon\', 45, 3),(\'Cathleen\', 11, 2),(\'Carry \', 50, 10),(\'Becky\', 125, 5),(\'Mars\', 21, 1),(\'Misho\', 5, 10),(\'Zoe\', 125, 5),(\'Json\', 21, 1)";
            insertInTablesCMD[3] = "INSERT INTO EvilnessFactors (Name) VALUES (\'Super good\'),(\'Good\'),(\'Bad\'), (\'Evil\'),(\'Super evil\')";
            insertInTablesCMD[4] = "INSERT INTO Villains (Name, EvilnessFactorId) VALUES (\'Gru\',2),(\'Victor\',1),(\'Jilly\',3),(\'Miro\',4),(\'Rosen\',5),(\'Dimityr\',1),(\'Dobromir\',2)";
            insertInTablesCMD[5] = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";
        }

        private static void FillTablesCommands(string[] createTablesCMD)
        {
            createTablesCMD[0] = "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))";
            createTablesCMD[1] = "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))";
            createTablesCMD[2] = "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))";
            createTablesCMD[3] = "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))";
            createTablesCMD[4] = "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))";
            createTablesCMD[5] = "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";
        }
    }
}
