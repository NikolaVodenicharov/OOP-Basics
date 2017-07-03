using System;

namespace VehiclesExtension
{
    class Bus : Vehicle
    {
        private const double AirConditionerConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionLiterPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionLiterPerKm, tankCapacity)
        {
        }

        public override double GetAirConditionerConsumption()
        {
            return AirConditionerConsumption;
        }
    }
}
