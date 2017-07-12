namespace ExamPreparationJune2016.PeopleInKarmen
{
    public class OldSingle : Household
    {
        private const double RoomConsumption = 15;
        private const int RoomNumber = 1;

        public OldSingle(double monthlyIncome) 
            : base(monthlyIncome)
        {
        }

        protected override double CalculateRoomsConsumption(double roomCosumption, int roomNumber)
        {
            return base.CalculateRoomsConsumption(RoomConsumption, RoomNumber);
        }
    }
}
