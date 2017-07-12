namespace ExamPreparationJune2016.PeopleInKarmen
{
    using System;

    public abstract class Couple : Household
    {
        private double fridge;
        private double television;

        public Couple(double monthlyIncome, double fridge, double television) 
            : base(monthlyIncome)
        {
            this.Fridge = fridge;
            this.Television = television;
        }

        public double Fridge
        {
            get
            {
                return this.fridge;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(Fridge)} must be positive number.");
                }

                this.fridge = value;
            }
        }

        public double Television
        {
            get
            {
                return this.television;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(Television)} must be positive number.");
                }

                this.television = value;
            }
        }

        public override int MemberCounter()
        {
            return 1 + base.MemberCounter();
        }

        public override double CalculateConsumption()
        {
            return this.fridge +
                   this.television +
                   base.CalculateConsumption();
        }
    }
}
