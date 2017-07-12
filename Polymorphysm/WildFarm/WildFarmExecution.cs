using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    class WildFarmExecution
    {
        static void Main()
        {
            var animals = new List<Animal>();
            var foods = new List<Food>();

            while (true)
            {
                var inputAnimal = Console.ReadLine().Split();

                if (inputAnimal[0].Equals("End", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                AddAnimal(animals, inputAnimal);

                var inputFood = Console.ReadLine().Split();
                AddFood(foods, inputFood);

                PrintOutput(animals, foods);
            }
        }

        private static void PrintOutput(List<Animal> animals, List<Food> foods)
        {
            animals.Last().MakeSound();

            try
            {
                animals.Last().Eat(foods.Last());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(animals.Last());
        }

        private static void AddFood(List<Food> foods, string[] inputFood)
        {
            var type = inputFood[0];
            var quantity = int.Parse(inputFood[1]);

            if (type.Equals("Meat", StringComparison.OrdinalIgnoreCase))
            {
                foods.Add(new Meat(quantity));
            }
            else if (type.Equals("Vegetable", StringComparison.OrdinalIgnoreCase))
            {
                foods.Add(new Vegetable(quantity));
            }
            else
            {
                // trow new ArgumentException("unknow food");
            }
        }

        private static void AddAnimal(List<Animal> animals, string[] inputAnimal)
        {
            var type = inputAnimal[0];
            var name = inputAnimal[1];
            var weight = double.Parse(inputAnimal[2]);
            var livingRegion = inputAnimal[3];

            if (type.Equals("Cat", StringComparison.OrdinalIgnoreCase))
            {
                var breed = inputAnimal[4];
                animals.Add(new Cat
                           (name, type, weight, livingRegion, breed));
            }
            else if (type.Equals("Tiger", StringComparison.OrdinalIgnoreCase))
            {
                animals.Add(new Tiger
                           (name, type, weight, livingRegion));
            }
            else if (type.Equals("Zebra", StringComparison.OrdinalIgnoreCase))
            {
                animals.Add(new Zebra
                           (name, type, weight, livingRegion));
            }
            else if (type.Equals("Mouse", StringComparison.OrdinalIgnoreCase))
            {
                animals.Add(new Mouse
                           (name, type, weight, livingRegion));
            }
            else
            {
                // trow new ArgumentException("unknow animal");
            }
        }
    }
}
