using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRadioDatabase.Exceptions
{
    class InvalidArtistNameException : InvalidSongException
    {
        private const string InvalidArtistName = "Artist name should be between 3 and 20 symbols.";

        public InvalidArtistNameException()
            : base(InvalidArtistName)
        {

        }

        public InvalidArtistNameException(string message)
            : base(message)
        {

        }
    }
}
