using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionLiterPerKm;

        public Vehicle (double fuelQuantity, double fuelConsumptionLiterPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionLiterPerKm = fuelConsumptionLiterPerKm;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumptionLiterPerKm
        {
            get
            {
                return this.fuelConsumptionLiterPerKm;
            }
            set
            {
                this.fuelConsumptionLiterPerKm = value;
            }
        }

        public abstract double GetAirConditionerConsumption();

        public void Drive(double distance)
        {
            double airConditionerConsumption = GetAirConditionerConsumption();
            var consumptionPerLiter = (FuelConsumptionLiterPerKm + airConditionerConsumption);
            var fuelConsumption = distance * consumptionPerLiter;

            if (this.FuelQuantity > fuelConsumption)
            {
                this.FuelQuantity -= fuelConsumption;

                // This is bad, i have to remove the message from here
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                // This is bad, i have to remove the message from here
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
