using System;

namespace WildFarm
{
    class Tiger : Felime
    {
        public const string FoodPrefereces = "Meat";

        // Constructor
        public Tiger(string name, string type, double weight, string livingRegion) 
            : base(name, type, weight,  livingRegion)
        {
        }

        public override string GiveFoodPreferences()
        {
            return FoodPrefereces;
        }


        // Methods
        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }
    }
}
