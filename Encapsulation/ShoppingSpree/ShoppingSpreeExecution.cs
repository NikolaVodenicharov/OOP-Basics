using System;
using System.Collections.Generic;
using System.Linq;

internal class ShoppingSpreeExecution
{
    static void Main()
    {
        var listOfPersons = new List<Person>();
        ReadFromConsoleAddToListOfPersons(listOfPersons);

        var listOfProducts = new List<Product>();
        ReadFromConsoleAddToListOfProducts(listOfProducts);

        while (true)
        {
            var inputLine = Console.ReadLine();

            var isTimeToStopLoop = inputLine.Equals("end", StringComparison.InvariantCultureIgnoreCase);
            if (isTimeToStopLoop)
            {
                break;
            }

            PurchaseProduct(listOfPersons, listOfProducts, inputLine);
        }

        foreach (var person in listOfPersons)
        {
            if (person.BagOfProducts.Count == 0)
            {
                Console.WriteLine($"{person.Name} - Nothing bought");
            }
            else
            {
                Console.WriteLine("{0} - {1}"
                                  , person.Name
                                  , string.Join(", ", person.BagOfProducts.Select(n => n.Name)));
            }
        }
    }

    private static void PurchaseProduct(List<Person> listOfPersons, List<Product> listOfProducts, string inputLine)
    {
        var splitLine = inputLine.Split();

        var personName = splitLine[0];
        var productName = splitLine[1];

        try
        {
            listOfPersons                                           // list
            .Single(n => n.Name == personName)                      // person
            .AddProductToBagOfProducts                              // method
            (listOfProducts.Single(x => x.Name == productName));    // product

            Console.WriteLine($"{personName} bought {productName}");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    private static void ReadFromConsoleAddToListOfProducts(List<Product> listOfProducts)
    {
        var inputProducts = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < inputProducts.Length; i++)
        {
            var inputProduct = inputProducts[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            var name = inputProduct[0];
            var cost = double.Parse(inputProduct[1]);

            listOfProducts.Add(new Product(name, cost));
        }
    }

    private static void ReadFromConsoleAddToListOfPersons(List<Person> listOfPersons)
    {
        var inputPersons = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < inputPersons.Length; i++)
        {
            var inputPerson = inputPersons[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            var name = inputPerson[0];
            var money = double.Parse(inputPerson[1]);

            try
            {
                listOfPersons.Add(new Person(name, money));     // (new global::Person(name, money));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(0);
            }
        }
    }
}

