using System;

public class Calculation
{
    public static double constantOfPlanck = 6.62606896e-34;
    //public static double constantOfPlanck = double.Parse("6.62606896e-34", System.Globalization.NumberStyles.Float);
    public static double constantPI = 3.141592;

    public static double ReducedPlanck ()
    {
        return constantOfPlanck / (2 * constantPI);
    }
}

class PlankConstantExecution
{
    static void Main()
    {
        Console.WriteLine(Calculation.ReducedPlanck());
    }
}
