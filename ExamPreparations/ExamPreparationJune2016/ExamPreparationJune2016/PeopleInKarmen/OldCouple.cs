namespace ExamPreparationJune2016.PeopleInKarmen
{
    using System;

    public class OldCouple : Couple
    {
        private const double RoomConsumption = 15;
        private const int RoomNumber = 3;
        private double stove;

        public OldCouple(double monthlyIncome, double fridge, double television, double stove) 
            : base(monthlyIncome, fridge, television)
        {
            this.Stove = stove;
        }

        public double Stove
        {
            get
            {
                return this.stove;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(Stove)} must be positive number.");
                }

                this.stove = value;
            }
        }

        public override double CalculateConsumption()
        {
            return this.stove +
                   base.CalculateConsumption();
        }

        protected override double CalculateRoomsConsumption(double roomCosumption, int roomNumber)
        {
            return base.CalculateRoomsConsumption(RoomConsumption, RoomNumber);
        }
    }
}