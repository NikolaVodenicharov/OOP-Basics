using System;

namespace VehiclesExtension.Exceptions
{
    class InvalidVeicleException : Exception
    {
        private const string InvalidVehicle = "Invalid vehicle.";

        public InvalidVeicleException ()
            : base ()
        {

        }

        public InvalidVeicleException (string message)
            : base (message)
        {

        }
    }
}
