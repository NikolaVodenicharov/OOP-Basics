namespace PizzaCalories.Pizzeria
{
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        private const int MinimumNameLength = 1;
        private const int MaximumNameLength = 15;
        private const int MaximumToppingsNumber = 10;

        private string name;
        private int toppingsNumber;
        private List<Topping> toppings;
        public Dough dough;

        public Pizza(string name, int numberOfToppings)
        {
            this.Name = name;
            this.ToppingsNumber = numberOfToppings;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                bool isInvalid =
                    string.IsNullOrEmpty(value) ||
                    value.Length < MinimumNameLength ||
                    value.Length > MaximumNameLength;

                if (isInvalid)
                {
                    throw new ArgumentException($"Pizza name should be between {MinimumNameLength} and {MaximumNameLength} symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            set
            {
                this.dough = value;
            }
        }

        public int ToppingsNumber
        {
            get
            {
                return this.toppingsNumber;
            }

            private set
            {
                if (value > 10)
                {
                    throw new ArgumentException($"Number of toppings should be in range [0..{MaximumToppingsNumber}]");
                }

                this.toppingsNumber = value;
            }
        }

        public double CalculatePizzaCaloriers()
        {
            double calories = this.dough.CalculateCalories();
            foreach (var topping in this.toppings)
            {
                calories += topping.CalculateCalories();
            }

            return calories;
        }

        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
        }

        public void PrintPizzaCalories()
        {
            Console.WriteLine($"{this.name} - {this.CalculatePizzaCaloriers():f2} Calories.");
        }
    }
}

    
