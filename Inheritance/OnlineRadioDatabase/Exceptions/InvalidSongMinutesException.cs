using System;

namespace OnlineRadioDatabase.Exceptions
{
    class InvalidSongMinutesException : InvalidSongLengthException
    {
        private const string InvalidSongMinutes = "Song minutes should be between 0 and 14.";

        public InvalidSongMinutesException ()
            :base (InvalidSongMinutes)
        {

        }

        public InvalidSongMinutesException (string message)
            :base (message)
        {

        }
    }
}
