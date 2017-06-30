using System;

namespace OnlineRadioDatabase.Exceptions
{
    class InvalidSongLengthException : InvalidSongException
    {
        private const string InvalidSongLength = "Song length should be between 0 second and 14 minutes and 59 seconds.";

        public InvalidSongLengthException()
            :base (InvalidSongLength)
        {

        }

        public InvalidSongLengthException (string message)
            :base (message)
        {

        }
    }
}
