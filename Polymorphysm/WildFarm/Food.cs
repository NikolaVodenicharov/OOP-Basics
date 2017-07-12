using System;

namespace WildFarm
{
    public abstract class Food
    {
        // Fields
        private int quantity;


        // Constructors
        public Food (int quantity)
        {
            this.Quantity = quantity;
        }


        // Properties
        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Food quantity cant be negative");
                }
                this.quantity = value;
            }
        }


        // Methods
        public string GetFoodType()
        {
            return this.GetType().Name;
        }
    }
}
