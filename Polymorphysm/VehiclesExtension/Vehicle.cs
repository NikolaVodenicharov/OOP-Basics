using System;
using VehiclesExtension.Exceptions;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        // Fields
        private double fuelQuantity;
        private double fuelConsumptionLiterPerKm;
        private double tankCapacity;


        // Constructors
        public Vehicle(double fuelQuantity, double fuelConsumptionLiterPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionLiterPerKm = fuelConsumptionLiterPerKm;
            this.TankCapacity = tankCapacity;
        }

        public Vehicle(double fuelQuantity, double fuelConsumptionLiterPerKm)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumptionLiterPerKm = fuelConsumptionLiterPerKm;
        }


        // Properties
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

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidTankCapacityException();
                }

                this.tankCapacity = value;
            }
        }


        // Methods
        public abstract double GetAirConditionerConsumption();

        private void Drive(double distance, double consumptionPerLiter)
        {
            var fuelConsumption = distance * consumptionPerLiter;

            if (this.fuelQuantity > fuelConsumption)
            {
                this.fuelQuantity -= fuelConsumption;
            }
            else
            {
                throw new InvalidDriveException($"{this.GetType().Name} needs refueling");
            }
        }

        public void DriveWithAirConditioner(double distance)
        {
            double airConditionerConsumption = GetAirConditionerConsumption();
            var consumptionPerLiter = (FuelConsumptionLiterPerKm + airConditionerConsumption);

            Drive(distance, consumptionPerLiter);
        }

        public void DriveWithoutAirConditioner(double distance)
        {
            Drive(distance, this.fuelConsumptionLiterPerKm);
        }

        public virtual void Refuel(double liters)
        {
            if (liters >= 0 &&
               (this.fuelQuantity + liters) <= TankCapacity)
            {
                this.fuelQuantity += liters;
            }
            else
            {
                throw new InvalidRefuelingException();
            }
        }
    }
}
