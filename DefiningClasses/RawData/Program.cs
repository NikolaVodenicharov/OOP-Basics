using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    class Tire
    {
        public double pressure;
        public double age;

        public Tire(double pressure, double age)
        {
            this.pressure = pressure;
            this.age = age;
        }

    }

    class Cargo
    {
        public double weight;
        public string type;    // fragile or flamable

        public Cargo (double weight, string type)
        {
            this.weight = weight;
            this.type = type;
        }
    }

    class Engine
    {
        public double speed;
        public double power;

        public Engine (double speed, double power)
        {
            this.speed = speed;
            this.power = power;
        }
    }

    class Car
    {
        public string model;
        public Engine engine;
        public Cargo cargo;
        public Tire[] tires;

        public Car (string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int amountOfInputCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(amountOfInputCars);

            for (int i = 0; i < amountOfInputCars; i++)
            {
                string[] inputCarInfo = Console.ReadLine().Split();
                Car car = AddCarInfo(inputCarInfo);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            PrintAnswer(cars, command);
        }

        private static void PrintAnswer(List<Car> cars, string command)
        {
            List<string> modelsCars = new List<string>();

            if (command.Equals("fragile", StringComparison.CurrentCultureIgnoreCase))
            {
                modelsCars = cars
                    .Where(c => c.cargo.type.Equals("fragile"))
                    .Where(t => t.tires.Any(p => p.pressure < 1))
                    .Select(x => x.model).ToList();
            }
            else if (command.Equals("flamable", StringComparison.CurrentCultureIgnoreCase))
            {
                modelsCars = cars
                    .Where(c => c.cargo.type.Equals("flamable"))
                    .Where(e => e.engine.power > 250)
                    .Select(x => x.model).ToList();
            }

            Console.WriteLine(String.Join(Environment.NewLine, modelsCars));
        }

        private static Car AddCarInfo(string[] inputCar)
        {
            string carModel = inputCar[0];

            double engineSpeed = double.Parse(inputCar[1]);
            double enginePower = double.Parse(inputCar[2]);

            double cargoWeight = double.Parse(inputCar[3]);
            string cargoType = inputCar[4];

            double tire1Presure = double.Parse(inputCar[5]);
            double tire1Age = double.Parse(inputCar[6]);
            double tire2Presure = double.Parse(inputCar[7]);
            double tire2Age = double.Parse(inputCar[8]);
            double tire3Presure = double.Parse(inputCar[9]);
            double tire3Age = double.Parse(inputCar[10]);
            double tire4Presure = double.Parse(inputCar[11]);
            double tire4Age = double.Parse(inputCar[12]);

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            Tire[] tire = new Tire[4];
            tire[0] = new Tire(tire1Presure, tire1Age);
            tire[1] = new Tire(tire2Presure, tire2Age);
            tire[2] = new Tire(tire3Presure, tire3Age);
            tire[3] = new Tire(tire4Presure, tire4Age);

            Car car = new Car(carModel, engine, cargo, tire);

            return car;
        }
    }
}
