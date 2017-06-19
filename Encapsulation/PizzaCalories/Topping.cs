using System;
using System.Collections.Generic;
using System.Linq;

class Topping
{
    private static double meatModifier = 1.2;
    private static double veggiesModifier = 0.8;
    private static double cheeseModifier = 1.1;
    private static double sauceModifier = 0.9;
    private static double caloriesBase = 2.0;

    private static HashSet<string> toppingsTypes = new HashSet<string>()
    {
        "Meat",
        "Veggies",
        "Cheese",
        "Sauce"
    };

    private string toppingType;
    public string ToppingType
    {
        get { return this.toppingType; }
        set
        {
            if (!toppingsTypes.Contains(value, StringComparer.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.toppingType = value;
        }
    }

    private double weight;
    public double Weight
    {
        get { return this.weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.toppingType} weight should be in the range[1..50].");
            }

            this.weight = value;
        }
    }

    private double toppingCalories;
    public double ToppingCalories
    {
        get { return CalculateToppingCalories(); }
    }

    public Topping (string toppingType, double weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    private double CalculateToppingCalories ()
    {
        double modifier = FindModifier();

        return this.weight * modifier * caloriesBase;
    }

    private double FindModifier()
    {
        var modifier = 0.0;

        switch (toppingType.ToLowerInvariant())
        {
            case "meat":
                modifier = meatModifier;
                break;
            case "veggies":
                modifier = veggiesModifier;
                break;
            case "cheese":
                modifier = cheeseModifier;
                break;
            case "sauce":
                modifier = sauceModifier;
                break;
        }

        return modifier;
    }
}
