using System;

namespace Vehicles
{
    class Car : Vehicle
    {
        private const double airConditionerConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionLiterPerKm) 
            : base(fuelQuantity, fuelConsumptionLiterPerKm)
        {
        }

        public override double GetAirConditionerConsumption()
        {
            return airConditionerConsumption;
        }
    }
}