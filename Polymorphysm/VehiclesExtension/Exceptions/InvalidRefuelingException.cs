using System;

namespace VehiclesExtension.Exceptions
{
    class InvalidRefuelingException : InvalidVeicleException
    {
        private const string Refueling = "Cannot fit fuel in tank";

        public InvalidRefuelingException()
            :base(Refueling)
        {

        }

        public InvalidRefuelingException(string message)
            :base(message)
        {

        }
    }
}
