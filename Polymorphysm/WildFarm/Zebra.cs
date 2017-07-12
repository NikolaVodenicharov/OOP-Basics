using System;

namespace WildFarm
{
    class Zebra : Mammal
    {
        public const string FoodPrefereces = "Vegetable";

        public Zebra(string name, string type, double weight, string livingRegion) 
            : base(name, type, weight, livingRegion)
        {
        }

        public override string GiveFoodPreferences()
        {
            return FoodPrefereces;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Zs");
        }

    }
}
