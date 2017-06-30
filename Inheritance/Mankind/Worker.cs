using System;

namespace Mankind
{
    class Worker : Human
    {
        private double weekSalary;
        private double workHoursPerDay;
        private double moneyEarnsByHour;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
            this.MoneyEarnsByHour = CalculateMoneyEarnsByHour();
        }

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
                    throw new ArgumentException("Expected value mismatch!Argument: weekSalary");
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
                    throw new ArgumentException("Expected value mismatch!Argumen: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        public double MoneyEarnsByHour
        {
            get
            {
                return this.moneyEarnsByHour;
            }
            set
            {
                this.moneyEarnsByHour = value;
            }
        }

        public double CalculateMoneyEarnsByHour()
        { 
            return this.weekSalary / (this.workHoursPerDay * 7);
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();

            sb.AppendLine(base.ToString())
              .AppendLine($"Week Salary: {this.WeekSalary}")
              .AppendLine($"Hours per day: {this.WorkHoursPerDay}")
              .Append($"Salary per hour: {this.MoneyEarnsByHour:f2}");

            return sb.ToString();
        }
    }
}
