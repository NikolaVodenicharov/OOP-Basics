using System;

namespace WildFarm
{
    class Mouse : Mammal
    {
        public const string FoodPrefereces = "Vegetable";

        public Mouse(string name, string type, double weight, string livingRegion) 
            : base(name, type, weight, livingRegion)
        {
        }

        public override string GiveFoodPreferences()
        {
            return FoodPrefereces;
        }

        public override void MakeSound()
        {
            Console.WriteLine("SQUEEEAAAK!");
        }


    }
}
