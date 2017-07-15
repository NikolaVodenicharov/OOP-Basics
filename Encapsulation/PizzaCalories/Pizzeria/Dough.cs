namespace PizzaCalories.Pizzeria
{
    using System;
    using System.Collections.Generic;

    public class Dough
    {
        private const double CaloriesBase = 2.0;
        private const double MinimumWeight = 1;
        private const double MaximumWeigth = 200;

        private static Dictionary<string, double> FlourTypeModifier = new Dictionary<string, double>()
        {
            ["white"] = 1.5,
            ["wholegrain"] = 1.0
        };

        private static readonly Dictionary<string, double> BakingTechniqueModifier = new Dictionary<string, double>()
        {
            ["crispy"] = 0.9,
            ["chewy"] = 1.1,
            ["homemade"] = 1.0
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            set
            {
                if (!FlourTypeModifier.ContainsKey(value.ToLowerInvariant()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value.ToLower();
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (!BakingTechniqueModifier.ContainsKey(value.ToLowerInvariant()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value.ToLower();
            }
        }

        private double Weight
        {
            set
            {
                if (value < MinimumWeight || value > MaximumWeigth)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinimumWeight}..{MaximumWeigth}].");
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            var calories = CaloriesBase *
                           FlourTypeModifier[this.flourType] *
                           BakingTechniqueModifier[this.bakingTechnique] *
                           this.weight;

            return calories;
        }

        public void PrintCalories()
        {
            Console.WriteLine("{0:f2}", this.CalculateCalories());
        }
    }
}