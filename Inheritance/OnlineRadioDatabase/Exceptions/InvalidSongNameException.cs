using System;

namespace OnlineRadioDatabase.Exceptions
{
    class InvalidSongNameException : InvalidSongException
    {
        private const string InvalidSongName = "Song name should be between 3 and 30 symbols.";

        public InvalidSongNameException()
            :base (InvalidSongName)
        {

        }

        public InvalidSongNameException (string message)
            :base (message)
        {

        }
    }
}
