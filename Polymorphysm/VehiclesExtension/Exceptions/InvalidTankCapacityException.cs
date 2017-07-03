using System;

namespace VehiclesExtension.Exceptions
{
    class InvalidTankCapacityException : InvalidVeicleException
    {
        private const string TankCapacity = "Fuel must be a positive number";

        public InvalidTankCapacityException ()
            : base(TankCapacity)
        {

        }

        public InvalidTankCapacityException (string message)
            : base (message)
        {

        }
    }
}
