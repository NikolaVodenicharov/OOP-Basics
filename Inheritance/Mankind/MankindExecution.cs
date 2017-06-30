using System;

namespace Mankind
{
    class MankindExecution
    {
        static void Main()
        {
            var inputStudentInfo = Console.ReadLine().Split();
            var studentFirstName = inputStudentInfo[0];
            var studentLastName = inputStudentInfo[1];
            var studentFacultiNumber = inputStudentInfo[2];

            var inputWorkerInfo = Console.ReadLine().Split();
            var workerFirstName = inputWorkerInfo[0];
            var workerLastName = inputWorkerInfo[1];
            var workerWeekSalary = double.Parse(inputWorkerInfo[2]);
            var workerWorkHoursPerDay = double.Parse(inputWorkerInfo[3]);

            try
            {
                var student = new Student(studentFirstName, studentLastName, studentFacultiNumber);
                var worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerWorkHoursPerDay);

                Console.WriteLine();
                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
