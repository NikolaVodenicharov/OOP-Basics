using System;

namespace WildFarm
{
    public abstract class Animal
    {
        // Fields
        private string name;
        private string type;
        private double weight;
        private int foodEaten;


        // Constructors
        public Animal (string name, string type, double weight)
        {
            this.Name = name;
            this.Type = type;
            this.Weight = weight;
            this.foodEaten = 0;
        }


        // Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || 
                    string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cant be null, empty or white space.");
                }

                this.name = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Type cant be null, empty or white space.");
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Weight cant be negative.");
                }

                this.weight = value;
            }
        }

        public int FoodEaten
        {
            get
            {
                return this.foodEaten;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Eaten food cant be negative.");
                }

                this.foodEaten = value;
            }
        }


        // Methods
        public abstract void MakeSound();

        public abstract string GiveFoodPreferences();

        public bool IsAnimalEatGivenFood(Food food)
        {
            if (GiveFoodPreferences() == "Everything")
            {
                return true;
            }
            else if (GiveFoodPreferences() == food.GetFoodType())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Eat(Food food)
        {
            if (IsAnimalEatGivenFood(food))
            {
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.Type}s are not eating that type of food!");
            }
        }
    }
}
