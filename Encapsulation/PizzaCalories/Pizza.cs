using System;
using System.Collections.Generic;

class Pizza
{
    private const int MinimumNameLength = 1;
    private const int MaximumNameLength = 15;
    private const int MaximumToppingsNumber = 10;
    private string name;
    private int numberOfToppings;
    private List<Topping> toppings;
    public Dough doughType;

    public Pizza(string name, int numberOfToppings)
    {
        this.Name = name;
        this.NumberOfToppings = numberOfToppings;
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

    private int NumberOfToppings
    {
        set
        {
            if (value > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.numberOfToppings = value;
        }
    }

    public Dough DoughType
    {
        set
        {
            this.doughType = value;
        }
    }

    public List<Topping> Toppings
    {
        get { return this.toppings; }
        set
        {
            if (value.Count > MaximumToppingsNumber)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MaximumToppingsNumber}");
            }

            this.toppings = value;
        }
    }

    public double CalculatePizzaCaloriers()
    {
        double calories = this.doughType.CalculateCalories();
        foreach (var topping in this.toppings)
        {
            calories += topping.CalculateCalories();
        }

        return calories;
    }
}
