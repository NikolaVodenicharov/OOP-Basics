using System;

namespace WildFarm
{
    class Cat : Felime
    {
        public const string FoodPrefereces = "Everything";
        // Fields
        private string breed;


        // Constructors
        public Cat(string name, string type, double weight,  string livingRegion, string breed) 
            : base(name, type, weight, livingRegion)
        {
            this.Breed = breed;
        }


        // Properties
        public string Breed
        {
            get
            {
                return this.breed;
            }
            set
            {
                this.breed = value;
            }
        }

        public override string GiveFoodPreferences()
        {
            return FoodPrefereces;
        }



        // Method
        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override string ToString()
        {
            return $"{base.Type}[{base.Name}, {this.breed}, {base.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
