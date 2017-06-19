using System;

public class CalculateVolume
{
    public static double TriangularPrism(double baseSide, double height, double length)
    {
        return 0.5 * baseSide * height * length;
    }

    public static double Cube (double side)
    {
        return side * side * side;
    }

    public static double Cylinder (double radius, double height)
    {
        return Math.PI * radius * radius * height;
    }
}

class ShapesVolumeExecution
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
            var figure = splitLine[0];

            switch (figure)
            {
                case "Cube":
                    var cubeVolume = CalculateVolume.Cube(double.Parse(splitLine[1]));
                    Console.WriteLine($"{cubeVolume:f3}");
                    break;

                case "Cylinder":
                    var cylinderVolume = CalculateVolume.Cylinder(double.Parse(splitLine[1]),
                                                                  double.Parse(splitLine[2]));
                    Console.WriteLine($"{cylinderVolume:f3}");
                    break;

                case "TrianglePrism":
                    var trianglePrismVolume = CalculateVolume.TriangularPrism(double.Parse(splitLine[1]),
                                                                              double.Parse(splitLine[2]),
                                                                              double.Parse(splitLine[3]));
                    Console.WriteLine($"{trianglePrismVolume:f3}");
                    break;
            }
        }
    }
}

