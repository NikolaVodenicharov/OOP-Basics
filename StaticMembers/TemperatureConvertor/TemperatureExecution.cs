using System;

public class TemperatureCalculation
{
    public static double CelsiusToFahrenheint(double temperature)
    {
        return temperature * 1.8 + 32;
    }

    public static double FahrenheintToCelsius(double temperature)
    {
        return (temperature - 32) / 1.8;
    }
}

class TemperatureExecution
{
    static void Main(string[] args)
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
            var temperature = double.Parse(splitedLine[0]);
            if (splitedLine[1].Equals("Celsius", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine($"{TemperatureCalculation.CelsiusToFahrenheint(temperature):f2} Fahrenheit");
            }
            else
            {
                Console.WriteLine($"{TemperatureCalculation.FahrenheintToCelsius(temperature):f2} Celsius");
            }
        }
    }
}

