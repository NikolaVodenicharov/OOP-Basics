namespace ExamPreparationJune2016.PeopleInKarmen
{
    using System.Collections.Generic;
    using System.Linq;

    public class YoungCoupleWithChilden : YoungCouple
    {
        private const double RoomConsumption = 30;
        private const int RoomNumber = 2;
        private List<Child> children;

        public YoungCoupleWithChilden(double monthlyIncome, double fridge, double television, double laptop, List<Child> children) 
            : base(monthlyIncome, fridge, television, laptop)
        {
            this.children = children;
        }

        public override int MemberCounter()
        {
            return this.children.Count +
                   base.MemberCounter();
        }

        public override double CalculateConsumption()
        {
            return this.children.Sum(x => x.Consumption()) + 
                   base.CalculateConsumption();
        }

        protected override double CalculateRoomsConsumption(double roomCosumption, int roomNumber)
        {
            return base.CalculateRoomsConsumption(RoomConsumption, RoomNumber);
        }
    }
}
