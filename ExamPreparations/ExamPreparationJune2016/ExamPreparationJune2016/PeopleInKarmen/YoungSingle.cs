namespace ExamPreparationJune2016.PeopleInKarmen
{
    using System;

    public class YoungSingle : Household
    {
        private const double RoomConsumption = 10;
        private const int RoomNumber = 1;
        private double laptop;

        public YoungSingle(double monthlyIncome, double laptop) 
            : base(monthlyIncome)
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
            return this.laptop + 
                   base.CalculateConsumption();
        }

        protected override double CalculateRoomsConsumption(double roomCosumption, int roomNumber)
        {
            return base.CalculateRoomsConsumption(RoomConsumption, RoomNumber);
        }
    }
}
