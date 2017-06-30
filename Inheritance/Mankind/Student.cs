using System;
using System.Text;

namespace Mankind
{
    class Student : Human
    {
        private string facultyNumber;

        public Student (string firstName, string lastName, string facultiNumber)
            : base(firstName, lastName)
        {
            this.FacultiNumber = facultiNumber;
        }

        public string FacultiNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString())
              .Append($"Faculty number: {this.FacultiNumber}");

            return sb.ToString();
        }
    }
}
