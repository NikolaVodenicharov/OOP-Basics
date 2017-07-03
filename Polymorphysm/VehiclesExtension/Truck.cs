﻿using System;

namespace VehiclesExtension
{
    class Truck : Vehicle
    {
        private const double airConditionerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionLiterPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionLiterPerKm, tankCapacity)
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