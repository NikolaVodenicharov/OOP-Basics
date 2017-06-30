using System;
using OnlineRadioDatabase.Exceptions;

namespace OnlineRadioDatabase
{
    class Song
    {
        private string artistName;
        private string songName;
        private int minutes;
        private int seconds;
        private static int playlistSeconds;

        public Song(string artistName, string songName, int minutes, int seconds)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public string ArtistName
        {
            get
            {
                return this.artistName;
            }
            set
            {
                if (value == null || value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();     //using OnlineRadioDatabase.Exceptions;
                }

                this.artistName = value;
            }
        }

        public string SongName
        {
            get
            {
                return this.songName;
            }
            set
            {
                if (value == null || value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidSongNameException();
                }

                this.songName = value;
            }
        }

        public int Minutes
        {
            get
            {
                return this.minutes;
            }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                this.minutes = value;
            }
        }

        public int Seconds
        {
            get
            {
                return this.seconds;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.seconds = value;
            }
        }

        private static int totalHours;
        private static int totalMinutes;
        private static int totalSeconds;
    }
}


