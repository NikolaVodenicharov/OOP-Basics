using System;
using System.Collections.Generic;

public class Student
{
    public string name;
    public static int counter;

    public Student (string name)
    {
        this.name = name;
        counter++;
    }
}
class StudentExecution
{
    static void Main(string[] args)
    {
        var students = new List<Student>();

        while (true)
        {
            var inputLine = Console.ReadLine();

            var isTimeToStopLoop = inputLine.Equals("end", StringComparison.InvariantCultureIgnoreCase);
            if (isTimeToStopLoop)
            {
                break;
            }

            students.Add(new Student(inputLine));
        }

        Console.WriteLine(Student.counter);
    }
}

