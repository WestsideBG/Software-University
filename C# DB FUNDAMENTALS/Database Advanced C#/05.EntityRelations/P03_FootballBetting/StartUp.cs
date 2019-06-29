using System;
using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new FootballBettingContext())
            {
                context.Database.EnsureCreated();

                context.Database.EnsureDeleted();
            }
        }
    }
}


