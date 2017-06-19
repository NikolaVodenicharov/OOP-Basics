using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRoster
{
    public class Employee
    {
        //name, salary, position, department, email and age. The name, salary, position and department are mandatory while the rest are optional. 

        public string name;
        public decimal salary;
        public string position;
        public string department;
        public string email = "n/a";
        public int age = -1;

        public Employee (string name, decimal salary, string position, string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfEmployees = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < numbersOfEmployees; i++)
            {
                string[] employeeInfo = Console.ReadLine().Split(' ');
                string name = employeeInfo[0];
                decimal salary = decimal.Parse(employeeInfo[1]);
                string position = employeeInfo[2];
                string department = employeeInfo[3];
                string email = null;
                int age = 0;

                if (employeeInfo.Length == 5)
                {
                    try
                    {
                        age = int.Parse(employeeInfo[4]);
                    }
                    catch
                    {
                        email = employeeInfo[4];
                    }
                }
                else if (employeeInfo.Length == 6)
                {
                    email = employeeInfo[4];
                    age = int.Parse(employeeInfo[5]);
                }

                Employee employee = new Employee(name, salary, position, department);

                if (email != null)
                {
                    employee.email = email;
                }

                if (age > 0)
                {
                    employee.age = age;
                }

                employees.Add(employee);
            }

            var result = employees
                .GroupBy(e => e.department)
                .Select(e => new
                {
                    Department = e.Key,
                    AverageSalary = e.Average(emp => emp.salary),
                    Employees = e.OrderByDescending(emp => emp.salary)
                })
                .OrderByDescending(e => e.AverageSalary)
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {result.Department}");

            foreach (var em in result.Employees)
            {
                Console.WriteLine($"{em.name} {em.salary:f2} {em.email} {em.age}");
            }
        }
    }
}
