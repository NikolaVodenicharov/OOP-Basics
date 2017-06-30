using System;

namespace OnlineRadioDatabase.Exceptions
{
    class InvalidSongSecondsException : InvalidSongLengthException
    {
        private const string InvalidSongSeconds = "Song seconds should be between 0 and 59.";

        public InvalidSongSecondsException ()
            :base (InvalidSongSeconds)
        {

        }

        public InvalidSongSecondsException (string message)
            :base (message)
        {

        }
    }
}
