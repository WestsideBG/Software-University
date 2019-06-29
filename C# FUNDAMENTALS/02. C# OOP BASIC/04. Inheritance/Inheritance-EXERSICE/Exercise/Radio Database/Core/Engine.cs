namespace Radio_Database.Core
{
    using RadioDatabase.Exceptions;
    using System;

    class Engine
    {
        public void Run()
        {
            int count = int.Parse(Console.ReadLine());
            double totalSeconds = 0;
            int songsAdded = 0;

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string[] songArgs = Console.ReadLine().Split(';');
                    string artistName = songArgs[0];
                    string songName = songArgs[1];
                    string[] minutesAndSeconds = songArgs[2].Split(':');
                    int minutes = int.Parse(minutesAndSeconds[0]);
                    int seconds = int.Parse(minutesAndSeconds[1]);

                    Song song = new Song(artistName, songName, minutes, seconds);
                    Console.WriteLine("Song added.");
                    totalSeconds += song.Length.TotalSeconds;
                    songsAdded++;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                
            }
            Print(totalSeconds,songsAdded);
           
        }

        public void Print(double totalSeconds, int songsAdded)
        {
            TimeSpan playlist = TimeSpan.FromSeconds(totalSeconds);

            Console.WriteLine($"Songs added: {songsAdded}");
            Console.WriteLine($"Playlist length: {playlist.Hours}h {playlist.Minutes}m {playlist.Seconds}s");

        }
    }
}
