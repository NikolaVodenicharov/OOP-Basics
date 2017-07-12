namespace ExamPreparationJune2016.PeopleInKarmen
{
    using System;

    public abstract class Household
    {
        private double money;
        private double monthlyIncome;

        public Household (double monthlyIncome)
        {
            this.MonthlyIncome = monthlyIncome;
        }

        public double MonthlyIncome
        {
            get
            {
                return this.monthlyIncome;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(MonthlyIncome)} must be positive number.");
                }

                this.monthlyIncome = value;
            }
        }

        // Methods
        public void AddMoney()
        {
            this.money += this.monthlyIncome;
        }

        public void PayBills ()
        {
                this.money -= this.CalculateConsumption();
        }

        public virtual int MemberCounter()
        {
            return 1;
        }

        public virtual double CalculateConsumption()
        {
            return this.CalculateRoomsConsumption(0, 0);
        }

        protected virtual double CalculateRoomsConsumption(double roomCosumption, int roomNumber)
        {
            return roomCosumption * roomNumber;
        }

        public bool CanPayBills()
        {
            return this.money > this.CalculateConsumption();
        }
    }
}
