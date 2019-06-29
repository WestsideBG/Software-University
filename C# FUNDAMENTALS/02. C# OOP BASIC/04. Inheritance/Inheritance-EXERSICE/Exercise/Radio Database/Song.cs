namespace RadioDatabase.Exceptions
{
    using Exceptions;
    using System;

    public class Song
    {
        private string artist;
        private string name;
        private TimeSpan length;

        private int minutes;
        private int seconds;

        public int Seconds
        {
            get { return seconds; }
            private set
            {
                if (value < 0 || value > 69)
                {
                    throw new InvalidSongSecondsException();
                }

                seconds = value;
            }
        }

        public int Minutes
        {
            get { return minutes; }
            private set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                minutes = value;
            }
        }


        public Song(string artist, string name, int minutes, int seconds)
        {
            this.Artist = artist;
            this.Name = name;
            this.Seconds = seconds;
            this.Minutes = minutes;
            double totalSeconds = minutes * 60 + seconds;
            this.Length = TimeSpan.FromSeconds(totalSeconds);
        }

        public TimeSpan Length
        {
            get { return length; }
            private set
            {
                if (default(TimeSpan) == value || value.TotalSeconds < 0)
                {
                    throw new InvalidSongLengthException();
                }

                length = value;
            }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidSongException();
                }

                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }

                name = value;
            }
        }


        public string Artist
        {
            get { return artist; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidSongException();
                }

                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                artist = value;
            }
        }

    }
}
