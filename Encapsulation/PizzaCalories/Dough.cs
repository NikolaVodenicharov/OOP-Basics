using System;
using System.Collections.Generic;

class Dough
{
    private static double whiteFlourTypeModifires = 1.5;
    private static double wholegrainFlourTypeModifires = 1.0;

    private static double crispyBakingTechniqueModifires = 0.9;
    private static double chewyBakingTechniqueModifires = 1.1;
    private static double homemadeBakingTechniqueModifires = 1.0;

    private static double basicCalories = 2.0;

    private static HashSet<string> flourTypes = new HashSet<string>()
    {
        "white",
        "wholegrain"
    };

    private static HashSet<string> bakingTechniques = new HashSet<string>()
    {
        "crispy",
        "chewy",
        "homemade"
    };

    private string flourType;
    public string FlourType
    {
        get { return this.flourType; }
        set
        {
            if (!flourTypes.Contains(value.ToLowerInvariant()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    private string bakingTechnique;
    public string BakingTechnique
    {
        get { return this.bakingTechnique; }
        set
        {
            if (!bakingTechniques.Contains(value.ToLowerInvariant()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
        }
    }

    private double weight;
    public double Weight
    {
        get { return this.weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            this.weight = value;
        }
    }

    private double doughCalories;
    public double DoughCalories
    {
        get { return CalculateDoughCalories(); }
        //set { this.totalCalories = CalculateCaloriesPerGram() * this.weight; }
    }

    public Dough (string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    private double CalculateDoughCalories ()
    {
        double flourTypeModifier = FindFlourTypeModifier();
        double bakingTechniqueModifier = FindBakingTechniqueModifier();

        var calories = basicCalories *
                       flourTypeModifier *
                       bakingTechniqueModifier *
                       this.weight;

        return calories;
    }

    private double FindFlourTypeModifier()
    {
        var flourTypeModifier = 0.0;
        switch (this.flourType.ToLowerInvariant())
        {
            case "white":
                flourTypeModifier = whiteFlourTypeModifires;
                break;
            case "wholegrain":
                flourTypeModifier = wholegrainFlourTypeModifires;
                break;
        }

        return flourTypeModifier;
    }

    private double FindBakingTechniqueModifier()
    {
        var bakingTechniqueModifier = 0.0;
        switch (this.bakingTechnique.ToLowerInvariant())
        {
            case "crispy":
                bakingTechniqueModifier = crispyBakingTechniqueModifires;
                break;
            case "chewy":
                bakingTechniqueModifier = chewyBakingTechniqueModifires;
                break;
            case "homemade":
                bakingTechniqueModifier = homemadeBakingTechniqueModifires;
                break;
        }

        return bakingTechniqueModifier;
    }
}

