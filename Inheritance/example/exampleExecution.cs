using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example
{
    class exampleExecution
    {
        static void Main(string[] args)
        {
            var pepi = new Pudel(7);

            Console.WriteLine(pepi.DogAge);

            var circle = new Circle(10, 20, 30);
            Console.WriteLine(circle.Radius);

            var figure = new Shape(2, 2);
            Console.WriteLine(figure.X + " " + figure.Y);
        }
    }
}
