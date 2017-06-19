using System;

public class BeerCounter
{
    public static int beerInStock;
    public static int beersDrankCount;

    public static void BuyBeer(int boughtBeers)
    {
        beerInStock += boughtBeers;
    }

    public static void DrinkBeer(int drankBeers)
    {
        beersDrankCount += drankBeers;
        beerInStock -= drankBeers;
    }
}

class BeerExecution
{
    static void Main()
    {
        while (true)
        {
            var inputLine = Console.ReadLine();

            var isTimeToStopLoop = inputLine.Equals("end", StringComparison.InvariantCultureIgnoreCase);
            if (isTimeToStopLoop)
            {
                break;
            }
            var splitedLine = inputLine.Split();
            BeerCounter.BuyBeer(int.Parse(splitedLine[0]));
            BeerCounter.DrinkBeer(int.Parse(splitedLine[1]));
        }

        Console.WriteLine($"{BeerCounter.beerInStock} {BeerCounter.beersDrankCount}");
    }
}

