using System;
using System.Collections.Generic;

public class PizzaCaloriesExecution
{
    public static void Main()
    {
        var pizzas = new List<Pizza>();
        var doughs = new List<Dough>();
        var toppings = new List<Topping>();

        try
        {
            MakeOrder(pizzas, doughs, toppings);
            AddIngridientToPizza(pizzas, doughs, toppings);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void AddIngridientToPizza(List<Pizza> pizzas, List<Dough> doughs, List<Topping> toppings)
    {
        if (pizzas.Count > 0)
        {
            pizzas[0].DoughType = doughs[0];
            pizzas[0].Toppings = toppings;
        }

        PrintPizaCalories(pizzas);
    }

    private static void MakeOrder(List<Pizza> pizzas, List<Dough> doughs, List<Topping> toppings)
    {
        while (true)
        {
            var inputLine = Console.ReadLine().Split();

            if (inputLine[0].Equals("end", StringComparison.InvariantCultureIgnoreCase))
            {
                break;
            }
            else if (inputLine[0].Equals("pizza", StringComparison.InvariantCultureIgnoreCase))
            {
                AddPizza(pizzas, inputLine);
            }
            else if (inputLine[0].Equals("dough", StringComparison.InvariantCultureIgnoreCase))
            {
                AddDough(doughs, inputLine, pizzas);
            }
            else if (inputLine[0].Equals("topping", StringComparison.InvariantCultureIgnoreCase))
            {
                AddTopping(toppings, inputLine, pizzas);
            }
            else
            {
                throw new ArgumentException("Invalid data");
            }
        }
    }

    private static void AddPizza(List<Pizza> pizzas, string[] inputLine)
    {
        pizzas.Add(
            new Pizza(
                inputLine[1], 
                int.Parse(inputLine[2])));
    }

    private static void AddTopping(List<Topping> toppings, string[] inputLine, List<Pizza> pizzas)
    {
        var type = inputLine[1];
        var weight = double.Parse(inputLine[2]);

        toppings.Add(
            new Topping(
                type,
                weight));

        if (pizzas.Count == 0)
        {
            PrintToppingCalories(toppings);
        }
    }

    private static void AddDough(List<Dough> doughs, string[] inputLine, List<Pizza> pizzas)
    {
        var flourType = inputLine[1];
        var bakingTechnique = inputLine[2];
        var weight = double.Parse(inputLine[3]);

        doughs.Add(
            new Dough(
                flourType,
                bakingTechnique,
                weight));

        if (pizzas.Count == 0)
        {
            PrintDoughCalories(doughs);
        }
    }

    private static void PrintPizaCalories(List<Pizza> pizzas)
    {
        foreach (var pizza in pizzas)
        {
            Console.WriteLine($"{pizza.Name} - {pizza.CalculatePizzaCaloriers():f2} Calories.");
        }
    }

    private static void PrintToppingCalories(List<Topping> toppings)
    {
        foreach (var topping in toppings)
        {
            Console.WriteLine("{0:f2}", topping.CalculateCalories());
        }
    }

    private static void PrintDoughCalories(List<Dough> doughs)
    {
        foreach (var dough in doughs)
        {
            Console.WriteLine("{0:f2}", dough.CalculateCalories());
        }
    }
}