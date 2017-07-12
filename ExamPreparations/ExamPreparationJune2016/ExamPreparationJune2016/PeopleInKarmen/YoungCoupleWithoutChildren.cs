namespace ExamPreparationJune2016.PeopleInKarmen
{
    public class YoungCoupleWithoutChildren : YoungCouple
    {
        private const double RoomConsumption = 20;
        private const int RoomNumber = 2;

        public YoungCoupleWithoutChildren(double monthlyIncome, double fridge, double television, double laptop) 
            : base(monthlyIncome, fridge, television, laptop)
        {
        }

        protected override double CalculateRoomsConsumption(double roomCosumption, int roomNumber)
        {
            return base.CalculateRoomsConsumption(RoomConsumption, RoomNumber);
        }
    }
}
