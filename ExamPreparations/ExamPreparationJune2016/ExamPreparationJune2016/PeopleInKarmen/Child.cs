namespace ExamPreparationJune2016.PeopleInKarmen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Child
    {
        private double food;
        private List<double> toys;

        public Child(double food, List<double> toys)
        {
            this.Food = food;
            this.toys = toys;
        }

        public double Food
        {
            get
            {
                return this.food;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(Food)} must be positive");
                }

                this.food = value;
            }
        }

        public double Consumption()
        {
            return this.food + this.toys.Sum(x => x);
        }
    }
}
