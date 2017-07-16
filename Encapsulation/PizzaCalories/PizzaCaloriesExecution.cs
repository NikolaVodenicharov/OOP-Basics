namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using Pizzeria;

    public class PizzaCaloriesExecution
    {
        public static void Main()
        {
            try
            {
                MakeOrder();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void MakeOrder()
        {
            while (true)
            {
                string inputLine = Console.ReadLine();
                string[] splitedLine = inputLine.Split();

                if (splitedLine[0].Equals("pizza", StringComparison.InvariantCultureIgnoreCase))
                {
                    var inputLines = new List<string>();
                    inputLines.Add(inputLine);
                    inputLines.AddRange(ConsoleReader());

                    Pizza pizza = PizzeriaFactory.MakePizza(inputLines);
                    pizza.PrintPizzaCalories();

                    break;
                }
                else if (splitedLine[0].Equals("dough", StringComparison.InvariantCultureIgnoreCase))
                {
                    Dough dough = PizzeriaFactory.MakeDough(splitedLine);
                    dough.PrintCalories();
                }
                else if (splitedLine[0].Equals("topping", StringComparison.InvariantCultureIgnoreCase))
                {
                    Topping topping = PizzeriaFactory.MakeTopping(splitedLine);
                    topping.PrintCalories();
                }
                else if (splitedLine[0].Equals("end", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    throw new ArgumentException("Invalid data");
                }
            }
        }

        private static List<string> ConsoleReader()
        {
            var inputLines = new List<string>();

            while (true)
            {
                var inputLine = Console.ReadLine();

                bool stopLoop = inputLine.Equals("end", StringComparison.InvariantCultureIgnoreCase);
                if (stopLoop)
                {
                    break;
                }

                inputLines.Add(inputLine);
            }

            return inputLines;
        }
    }
}