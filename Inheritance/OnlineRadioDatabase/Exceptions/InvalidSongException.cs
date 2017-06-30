using System;

namespace OnlineRadioDatabase.Exceptions
{
    class InvalidSongException : Exception
    {
        private const string InvalidSong = "Invalid song.";

        public InvalidSongException()
            :base (InvalidSong)
        {

        }

        public InvalidSongException (string message)
            :base (message)
        {

        }
    }
}
