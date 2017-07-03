using System;

namespace VehiclesExtension
{
    class Car : Vehicle
    {
        private const double airConditionerConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionLiterPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionLiterPerKm, tankCapacity)
        {
        }

        public override double GetAirConditionerConsumption()
        {
            return airConditionerConsumption;
        }
    }
}