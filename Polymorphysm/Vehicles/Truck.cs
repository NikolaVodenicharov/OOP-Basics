using System;

namespace Vehicles
{
    class Truck : Vehicle
    {
        private const double airConditionerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionLiterPerKm) 
            : base(fuelQuantity, fuelConsumptionLiterPerKm)
        {
        }

        public override double GetAirConditionerConsumption()
        {
            return airConditionerConsumption;
        }

        public override void Refuel(double liters)
        {
            liters *= 0.95;
            base.Refuel(liters);
        }
    }
}