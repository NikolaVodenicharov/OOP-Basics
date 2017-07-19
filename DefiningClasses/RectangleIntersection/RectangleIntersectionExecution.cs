namespace RectangleIntersection
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class RectangleIntersectionExecution
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rectangles = new List<Rectangle>();

            var inputRectangleNumber = input[0];
            for (int i = 0; i < inputRectangleNumber; i++)
            {
                var rectangleInfo = Console.ReadLine().Split();
                var rectangle = CreateRectangle(rectangleInfo);
                rectangles.Add(rectangle);
            }

            var checkingPairs = input[1];
            for (int i = 0; i < checkingPairs; i++)
            {
                var pair = Console.ReadLine().Split();
                var firstID = pair[0];
                var secondID = pair[1];

                bool areRectanglesExist = 
                    rectangles.Any(x => x.id == firstID) && 
                    rectangles.Any(x => x.id == secondID);

                if (areRectanglesExist)
                {
                    var rectangle1 = rectangles.First(x => x.id == firstID);
                    var rectangle2 = rectangles.First(x => x.id == secondID);

                    var areIntersect = AreRectanglesIntersect(rectangle1, rectangle2);

                    Console.WriteLine(areIntersect.ToString().ToLower());
                }
            }
        }

        private static Rectangle CreateRectangle(string[] rectangleInfo)
        {
            var id = rectangleInfo[0];
            var width = double.Parse(rectangleInfo[1]);
            var height = double.Parse(rectangleInfo[2]);
            var x = double.Parse(rectangleInfo[3]);
            var y = double.Parse(rectangleInfo[4]);

            var topLeft = new Point(x, y);
            var rectangle = new Rectangle(id, width, height, topLeft);

            return rectangle;
        }

        private static bool AreRectanglesIntersect(Rectangle rectangle1, Rectangle rectangle2)
        {
            bool areIntersect = rectangle1.topLeft.x <= rectangle2.bottomRight.x &&
                                rectangle1.topLeft.y <= rectangle2.bottomRight.y &&
                                rectangle1.bottomRight.x >= rectangle2.topLeft.x &&
                                rectangle1.bottomRight.y >= rectangle2.topLeft.y;

            return areIntersect;
        }
    }

    public class Rectangle
    {
        public string id;
        private double width;
        private double height;
        public Point topLeft;
        public Point bottomRight;

        public Rectangle (string id, double width, double height, Point topLeft)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.topLeft = topLeft;
            this.bottomRight = CalulateBottomRight();
        }

        private Point CalulateBottomRight()
        {
            double x = this.topLeft.x + this.width;
            double y = this.topLeft.y + height;
            Point bottomRightPoint = new Point(x, y);

            return bottomRightPoint;
        }
    }

    public class Point
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
