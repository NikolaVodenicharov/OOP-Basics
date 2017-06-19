using System;
using System.Linq;
using System.Reflection;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box (double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get { return this.length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
            }

            this.length = value;
        }
    }

    public double Width
    {
        get { return this.width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
            }

            this.width = value;
        }
    }

    public double Height
    {
        get { return this.height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
            }

            this.height = value;
        }
    }

    public double Volume()
    {
        return this.length * this.width * this.height;
    }

    public double LateralSurfaceArea ()
    {
        return 2 * this.length * this.height + 
               2 * this.width * this.height;
    }

    public double SurfaceArea()
    {
        return 2 * this.length * this.height + 
               2 * this.width * this.height + 
               2 * this.length * this.width;
    }

    public override string ToString()
    {
        var result = $"Surface Area - {this.SurfaceArea():f2}" + 
                     Environment.NewLine +
                     $"Lateral Surface Area - {this.LateralSurfaceArea():f2}" + 
                     Environment.NewLine +
                     $"Volume - {this.Volume():f2}";
        return result;
    }
}

class BoxClassExecution
{
    static void Main()
    {
        var length = double.Parse(Console.ReadLine());
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());

        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        try
        {
            var inputBox = new Box(length, width, height);
            Console.WriteLine(inputBox);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}

