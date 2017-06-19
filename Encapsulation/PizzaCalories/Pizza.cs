using System;
using System.Collections.Generic;

class Pizza
{
    private string name;
    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value) || 
                value.Length < 1 || 
                value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    private Dough _dough;
    public Dough _Dough
    {
        get { return this._dough; }
        set { this._dough = value; }
    }

    private int numberOfToppings;
    public int NumberOfToppings
    {
        get { return this.numberOfToppings; }
        set
        {
            if (value > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.numberOfToppings = value;
        }
    }

    private List<Topping> toppings = new List<Topping>();
    public List<Topping> Toppings
    {
        get { return this.toppings; }
        set
        {
            if (value.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings = value;
        }
    }

    public Pizza()
    {

    }

    public Pizza(string name, int numberOfToppings)
    {
        this.Name = name;
        this.NumberOfToppings = numberOfToppings;
        this.Toppings = new List<Topping>();
    }


    public double CalculatePizzaCaloriers()
    {
        var calories = 0.0;

        calories += this._dough.DoughCalories;

        foreach (var topping in this.toppings)
        {
            calories += topping.ToppingCalories;
        }

        return calories;
    }
}
