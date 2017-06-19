using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfInputCars; i++)
            {
                string[] inputCar = Console.ReadLine().Split();
                string model = inputCar[0];
                decimal fuelAmount = decimal.Parse(inputCar[1]);
                decimal fuelConsumptionPerKm = decimal.Parse(inputCar[2]);

                var car = new Car(model, fuelAmount, fuelConsumptionPerKm);
                cars.Add(car);
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0].Equals("end", StringComparison.CurrentCultureIgnoreCase))
                {
                    break;
                }

                // input[0] will be drive. So i dont need it.
                string model = input[1];
                decimal distanceForTraveling = decimal.Parse(input[2]);
                Car carToDrive = cars.First(c => c.model == model);
                carToDrive.Drive(distanceForTraveling);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.model} {car.fuelAmount:f2} {car.distanceTraveled}");
            }

        }
    }

    class Car
    {
        public string model;
        public decimal fuelAmount;
        public decimal fuelConsumptionPerKm;
        public decimal distanceTraveled;

        public Car(string model, decimal fuelAmount, decimal fuelConsumptionPerKm)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKm = fuelConsumptionPerKm;
            this.distanceTraveled = 0;
        }

        public void Drive (decimal distanceForTraveling)
        {
            if (distanceForTraveling <= this.fuelAmount / this.fuelConsumptionPerKm)
            {
                this.fuelAmount -= this.fuelConsumptionPerKm * distanceForTraveling;
                this.distanceTraveled += distanceForTraveling;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

        }
    }
}
