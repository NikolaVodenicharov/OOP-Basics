using System;
using System.Collections.Generic;
using System.Linq;

class Topping
{
    private const double CaloriesBase = 2.0;
    private const double MinimumWeight = 1;
    private const double MaximumWeigth = 50;

    private static Dictionary<string, double> ToppingModifier = new Dictionary<string, double>()
    {
        ["meat"] = 1.2,
        ["veggies"] = 0.8,
        ["cheese"] = 1.1,
        ["sauce"] = 0.9
    };

    private string type;
    private double weight;

    public Topping(string toppingType, double weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    private string ToppingType
    {
        set
        {
            if (!ToppingModifier.ContainsKey(value.ToLowerInvariant()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.type = value.ToLowerInvariant();
        }
    }

    private double Weight
    {
        set
        {
            if (value < MinimumWeight || value > MaximumWeigth)
            {
                string toppingType = UppercaseFirst(this.type);
                throw new ArgumentException($"{toppingType} weight should be in the range [{MinimumWeight}..{MaximumWeigth}].");
            }

            this.weight = value;
        }
    }

    public double CalculateCalories ()
    {
        var calories = this.weight * ToppingModifier[type] * CaloriesBase;

        return calories;
    }

    private static string UppercaseFirst(string s)
    {
        // Check for empty string.
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        // Return char and concat substring.
        return char.ToUpper(s[0]) + s.Substring(1);
    }
}
