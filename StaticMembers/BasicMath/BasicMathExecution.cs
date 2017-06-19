using System;

public class MathUtil
{
    public static double Sum (double num1, double num2)
    {
        return num1 + num2;
    }

    public static double Substract (double num1, double num2)
    {
        return num1 - num2;
    }

    public static double Multiply (double num1, double num2)
    {
        return num1 * num2;
    }

    public static double Divide (double num1, double num2)
    {
        return num1 / num2;
    }

    public static double Percentage (double num1, double percentage)
    {
        return num1 * (percentage / 100);
    }
}

class BasicMathExecution
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

            var splitLine = inputLine.Split();
            var command = splitLine[0];
            var num1 = double.Parse(splitLine[1]);
            var num2orPercentage = double.Parse(splitLine[2]);

            switch (command)
            {
                case "Sum":
                    Console.WriteLine($"{MathUtil.Sum(num1, num2orPercentage):f2}");
                    break;

                case "Multiply":
                    Console.WriteLine($"{MathUtil.Multiply(num1, num2orPercentage):f2}");
                    break;

                case "Percentage":
                    Console.WriteLine($"{MathUtil.Percentage(num1, num2orPercentage):f2}");
                    break;

                case "Divide":
                    Console.WriteLine($"{MathUtil.Divide(num1, num2orPercentage):f2}");
                    break;

                case "Subtract":
                    Console.WriteLine($"{MathUtil.Substract(num1, num2orPercentage):f2}");
                    break;
            }
        }
    }
}

