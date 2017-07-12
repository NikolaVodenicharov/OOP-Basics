using System;

namespace Mankind
{
    class Worker : Human
    {
        private const int WorkDayPerWeek = 5;
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        //public override string LastName
        //{
        //    get
        //    {
        //        return base.LastName;
        //    }
        //    set
        //    {
        //        if (value.Length <= 3)
        //        {
        //            throw new ArgumentException("Expected length more than 3 symbols! Argument: lastName");
        //        }

        //        base.LastName = value;
        //    }
        //}


        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argumen: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        public double CalculateMoneyEarnsByHour()
        { 
            return this.weekSalary / (this.workHoursPerDay * WorkDayPerWeek);
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();

            sb.AppendLine(base.ToString())
              .AppendLine($"Week Salary: {this.WeekSalary:f2}")
              .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
              .Append($"Salary per hour: {this.CalculateMoneyEarnsByHour():f2}");

            return sb.ToString();
        }
    }
}
