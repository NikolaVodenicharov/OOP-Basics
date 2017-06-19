using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{   
    class Car
    {
        public string model;
        public Engine engine;
        public int weight;          //optional
        public string color;        //optional

        public Car(string model, Engine engine)
            :this(model, engine, -1, "n/a")
        {

        }

        public Car(string model, Engine engine, int weight)
            :this(model, engine, weight, "n/a")
        {

        }

        public Car(string model, Engine engine, string color)
            :this(model, engine, -1, color)
        {

        }

        public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }

        private const string offset = "  ";
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.model}:");
            sb.AppendLine($"{this.engine}");
            sb.AppendFormat("{0}Weight: {1}", offset, this.weight == -1 ? "n/a" : this.weight.ToString());
            sb.Append(Environment.NewLine);
            sb.Append($"{offset}Color: {this.color}");

            return sb.ToString();
        }
    }

    class Engine
    {
        public string model;
        public int power;        
        public int displacement;    //optional
        public string efficiency;   //optional


        public Engine(string model, int power) 
            :this(model, power, -1, "n/a")
        {

        }

        public Engine(string model, int power, int displacement) 
            :this(model, power, displacement, "n/a")
        {

        }

        public Engine(string model, int power, string efficiency) 
            :this(model, power, -1, efficiency)
        {

        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        private const string offset = "  ";
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{offset}{this.model}:");
            sb.AppendLine($"{offset}{offset}Power: {this.power}");
            sb.AppendFormat("{0}{0}Displacement: {1 }", offset, this.displacement == -1 ? "n/a" : this.displacement.ToString());
            sb.Append(Environment.NewLine);
            sb.Append($"{offset}{offset}Efficiency: {this.efficiency}");

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // imput engines
            List<Engine> engines = new List<Engine>();
            int numberOfInputEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputEngines; i++)
            {
                string[] inputEngine = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

                Engine engine = AddEngine(inputEngine);

                engines.Add(engine);
            }

            //imout cars
            List<Car> cars = new List<Car>();
            int numberOfInputCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputCars; i++)
            {
                string[] inputCar = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

                Car car = AddCar(engines, inputCar);

                cars.Add(car);
            }

            // print cars
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static Car AddCar(List<Engine> engines, string[] inputCar)
        {
            Car car = null;
            Engine engine = engines.Find(e => e.model == inputCar[1]);
            int weight = 0;

            if (inputCar.Length == 2)
            {
                car = new Car(inputCar[0], engine);
            }
            else if (inputCar.Length == 4)
            {
                car = new Car(inputCar[0], engine, int.Parse(inputCar[2]), inputCar[3]);
            }
            else if ((inputCar.Length == 3) &&
                     (int.TryParse(inputCar[2], out weight)))
            {
                car = new Car(inputCar[0], engine, weight);
            }
            else
            {
                car = new Car(inputCar[0], engine, inputCar[2]);
            }

            return car;
        }

        private static Engine AddEngine(string[] inputEngine)
        {
            Engine engine = null;
            int displacement = 0;

            if (inputEngine.Length == 2)
            {
                engine = new Engine(inputEngine[0], int.Parse(inputEngine[1]));
            }
            else if ((inputEngine.Length == 3) &&
                     (int.TryParse(inputEngine[2], out displacement)))
            {
                engine = new Engine(inputEngine[0], int.Parse(inputEngine[1]), displacement);
            }
            else if (inputEngine.Length == 4)
            {
                engine = new Engine(inputEngine[0], int.Parse(inputEngine[1]), int.Parse(inputEngine[2]), inputEngine[3]);
            }
            else
            {
                engine = new Engine(inputEngine[0], int.Parse(inputEngine[1]), inputEngine[2]);
            }

            return engine;
        }
    }
}
