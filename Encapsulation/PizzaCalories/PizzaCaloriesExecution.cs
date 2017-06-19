using System;
using System.Collections.Generic;

class PizzaCaloriesExecution
{
    static void Main()
    {
        var pizzas = new List<Pizza>();

        while (true)
        {
            var inputLine = Console.ReadLine();

            var isTimeToStopLoop = inputLine.Equals("end", StringComparison.InvariantCultureIgnoreCase);
            if (isTimeToStopLoop)
            {
                break;
            }

            var inputLinePizza = inputLine.Split();
            var numberOfToppings = int.Parse(inputLinePizza[2]);
            var inputPizza = new Pizza();
            AddNameAndNumberOfToppigsToPizza(inputLinePizza, numberOfToppings, inputPizza);

            var inputLineDough = Console.ReadLine().Split();
            AddDoughToPizza(inputLineDough, inputPizza);

            AddToppingsToPizza(numberOfToppings, inputPizza);

            pizzas.Add(inputPizza);
        }

        PrintNameAndCaloriesForeachPizza(pizzas);
    }

    private static void AddNameAndNumberOfToppigsToPizza(string[] inputLinePizza, int numberOfToppings, Pizza inputPizza)
    {
        var name = inputLinePizza[1];
        try
        {
            inputPizza.Name = name;
            inputPizza.NumberOfToppings = numberOfToppings;
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            Environment.Exit(0);
        }
    }

    private static void PrintNameAndCaloriesForeachPizza(List<Pizza> pizzas)
    {
        foreach (var pizza in pizzas)
        {
            Console.WriteLine($"{pizza.Name} – {pizza.CalculatePizzaCaloriers():f2} Calories.");
        }
    }

    private static void AddDoughToPizza(string[] inputLineDough, Pizza inputPizza)
    {
        var flourType = inputLineDough[1];
        var bakingTechnique = inputLineDough[2];
        var weight = double.Parse(inputLineDough[3]);

        try
        {
            var inputDough = new Dough(flourType, bakingTechnique, weight);
            inputPizza._Dough = inputDough;
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            Environment.Exit(0); ;
        }
    }

    private static void AddToppingsToPizza(int numberOfToppings, Pizza inputPizza)
    {
        for (int i = 0; i < numberOfToppings; i++)
        {
            var inputLineTopping = Console.ReadLine().Split();
            var type = inputLineTopping[1];
            var weight = double.Parse(inputLineTopping[2]);

            try
            {
                var inputTopping = new Topping(type, weight);
                inputPizza.Toppings.Add(inputTopping);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(0);
            }
        }
    }
}

