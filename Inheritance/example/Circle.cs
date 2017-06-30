using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example
{
    class Circle : Shape
    {
        public Circle (int x, int y, double radius) : base(x, y)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }
    }
}
