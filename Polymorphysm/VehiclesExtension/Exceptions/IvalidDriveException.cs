using System;

namespace VehiclesExtension.Exceptions
{
    class InvalidDriveException : InvalidVeicleException
    {
        private const string Drive = "needs refueling";
        
        public InvalidDriveException()
            :base(Drive)
        {

        }

        public InvalidDriveException(string message)
            :base(message)
        {

        }
    }
}
