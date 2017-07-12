using System;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        // Fields
        private string livingRegion;


        // Constructors
        public Mammal(string name, string type, double weight, string livingRegion) 
            : base(name, type, weight)
        {
            this.LivingRegion = livingRegion;
        }


        // Properties
        public string LivingRegion
        {
            get
            {
                return this.livingRegion;
            }
            set
            {
                this.livingRegion = value;
            }
        }


        // Methods
        public override string ToString()
        {
            return $"{base.Type}[{base.Name}, {base.Weight}, {this.livingRegion}, {base.FoodEaten}]";
        }
    }
}
