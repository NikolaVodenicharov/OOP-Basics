using System;
using System.Collections.Generic;
using System.Linq;

public class ShoppingSpreeExecution
{
    public static void Main()
    {
        var persons = new List<Person>();
        ReadFromConsoleAddToPersons(persons);

        var products = new List<Product>();
        ReadFromConsoleAddToProducts(products);

        while (true)
        {
            var inputLine = Console.ReadLine();

            var isTimeToStopLoop = inputLine.Equals("end", StringComparison.InvariantCultureIgnoreCase);
            if (isTimeToStopLoop)
            {
                break;
            }

            PurchaseProduct(persons, products, inputLine);
        }

        foreach (var person in persons)
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

    private static void PurchaseProduct(List<Person> persons, List<Product> products, string inputLine)
    {
        var splitLine = inputLine.Split();

        var personName = splitLine[0];
        var productName = splitLine[1];

        try
        {
            persons                                           // list
            .Single(n => n.Name == personName)                      // person
            .AddProductToBagOfProducts                              // method
            (products.Single(x => x.Name == productName));    // product

            Console.WriteLine($"{personName} bought {productName}");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    private static void ReadFromConsoleAddToProducts(List<Product> products)
    {
        var inputProducts = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < inputProducts.Length; i++)
        {
            var inputProduct = inputProducts[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            var name = inputProduct[0];
            var money = double.Parse(inputProduct[1]);

            try
            {
                products.Add(new Product(name, money));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(0);
            }
        }
    }

    private static void ReadFromConsoleAddToPersons(List<Person> persons)
    {
        var inputPersons = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < inputPersons.Length; i++)
        {
            var inputPerson = inputPersons[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            var name = inputPerson[0];
            var money = double.Parse(inputPerson[1]);

            try
            {
                persons.Add(new Person(name, money));     // (new global::Person(name, money));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(0);
            }
        }
    }
}

