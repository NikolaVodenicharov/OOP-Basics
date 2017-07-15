namespace PizzaCalories.Pizzeria
{
    using System.Collections.Generic;

    public static class PizzeriaFactory
    {
        public static Pizza MakePizza(List<string> inputLines)
        {
            string[] pizzaInfo = inputLines[0].Split();
            var name = pizzaInfo[1];
            var toppingsNumber = int.Parse(pizzaInfo[2]);
            Pizza pizza = new Pizza(name, toppingsNumber);

            var doughInfo = inputLines[1].Split();
            var dough = MakeDough(doughInfo);
            pizza.Dough = dough;

            for (int i = 2; i < inputLines.Count; i++)
            {
                var toppingInfo = inputLines[i].Split();
                Topping topping = MakeTopping(toppingInfo);

                pizza.AddTopping(topping);
            }

            return pizza;
        }

        public static Topping MakeTopping(string[] toppingInfo)
        {
            var type = toppingInfo[1];
            var weight = double.Parse(toppingInfo[2]);
            Topping topping = new Topping(type, weight);

            return topping;
        }

        public static Dough MakeDough(string[] doughInfo)
        {
            var flourType = doughInfo[1];
            var bakingTechnique = doughInfo[2];
            var weight = double.Parse(doughInfo[3]);
            Dough dough = new Dough(flourType, bakingTechnique, weight);

            return dough;
        }
    }
}
