using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteMe
{
    public abstract class Animal
    {
        string name;
        string favourFood;
        int age;

        public Animal(string name, string favourFood, int age)
        {
            this.name = name;
            this.favourFood = favourFood;
            this.age = age;
        }

        public virtual string StateFavFood()
        {
            return this.favourFood;
        }

        public abstract void MakeNoise();

        public abstract void ConsumeFood(Food food);
    }

    public class Penguin : Animal
    {
        public int wingPower;

        public Penguin(string name, string favourFood, int age)
            :base (name, favourFood, age)
        {
        }

        public override void ConsumeFood(Food food)
        {
            this.wingPower += food.nutritionValue;
        }

        public override void MakeNoise()
        {
            Console.WriteLine("Peep");
        }
    }

    public class Cow : Animal
    {
        public int bodyMassIndex;

        public Cow (string name, string favourFood, int age)
            :base (name, favourFood, age)
        {
        }

        public override void ConsumeFood(Food food)
        {
            this.bodyMassIndex += food.nutritionValue / 2;
        }

        public override void MakeNoise()
        {
            Console.WriteLine("Mooo");
        }
    }

    public abstract class Food
    {
        public string name;
        public int nutritionValue;

        public Food(string name, int nutritionValue)
        {
            this.name = name;
            this.nutritionValue = nutritionValue;
        }
    }

    public class Seaweed : Food
    {
        public Seaweed (string name, int nutritionValue)
            :base(name, nutritionValue)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal pegy = new Penguin("gosho", "milk", 5);
            Animal peny = new Cow("peny", "rise", 7);

            pegy.StateFavFood();

            var animals = new List<Animal>();
            animals.Add(pegy);
            animals.Add(peny);

            foreach (var animal in animals)
            {
                var food = animal.StateFavFood();
            }
        }
    }
}
