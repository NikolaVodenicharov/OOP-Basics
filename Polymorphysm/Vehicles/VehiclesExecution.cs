using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicles
{
    class VehiclesExecution
    {
        static void Main()
        {
            var vehicles = new List<Vehicle>();

            var carInfo = Console.ReadLine().Split();
            vehicles.Add(new Car(double.Parse(carInfo[1]),
                                    double.Parse(carInfo[2])));

            var truckInfo = Console.ReadLine().Split();
            vehicles.Add(new Truck(double.Parse(truckInfo[1]),
                                      double.Parse(truckInfo[2])));

            var numberOfInputCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputCommands; i++)
            {
                var inputCommandLine = Console.ReadLine().Split();

                var command = inputCommandLine[0];
                var vehicleType = inputCommandLine[1];

                if (command.Equals("Drive", StringComparison.OrdinalIgnoreCase))
                {
                    double distance = double.Parse(inputCommandLine[2]);
                    vehicles.FirstOrDefault(x => x.GetType().Name.ToString() == vehicleType).Drive(distance);
                }
                else if (command.Equals("Refuel", StringComparison.OrdinalIgnoreCase))
                {
                    double liters = double.Parse(inputCommandLine[2]);
                    vehicles.FirstOrDefault(x => x.GetType().Name.ToString() == vehicleType).Refuel(liters);
                }
            }

            PrintRemainingFuelInEachVehicle(vehicles);
        }

        private static void PrintRemainingFuelInEachVehicle(List<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.GetType().Name}: {vehicle.FuelQuantity:f2}");
            }
        }
    }
}
