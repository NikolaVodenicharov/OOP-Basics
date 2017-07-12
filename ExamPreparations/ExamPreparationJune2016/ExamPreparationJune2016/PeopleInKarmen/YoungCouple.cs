namespace ExamPreparationJune2016.PeopleInKarmen
{
    using System;

    public abstract class YoungCouple : Couple
    {
        private double laptop;

        public YoungCouple(double monthlyIncome, double fridge, double television, double laptop) 
            : base(monthlyIncome, fridge, television)
        {
            this.Laptop = laptop;
        }

        public double Laptop
        {
            get
            {
                return this.laptop;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(Laptop)} must be positive number.");
                }

                this.laptop = value;
            }
        }

        public override double CalculateConsumption()
        {
            return (this.laptop * 2) +
                   base.CalculateConsumption();
        }
    }
}
