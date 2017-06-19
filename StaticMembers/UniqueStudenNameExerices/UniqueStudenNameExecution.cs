using System;
using System.Collections.Generic;

public class Student
{
    public static HashSet<Student> allStudents = new HashSet<string>();
    public string name;

    public Student(string name)
    {
        this.name = name;
    }

    public override bool Equals(object other)
    {
        return this.GetHashCode().Equals(other.GetHashCode());
    }

    public override int GetHashCode()
    {
        return this.name.GetHashCode();
    }
}


class UniqueStudenNameExecution
{
    static void Main()
    {
        var students = new HashSet<string>();
        while (true)
        {
            var inputLine = Console.ReadLine();

            var isTimeToStopLoop = inputLine.Equals("end", StringComparison.InvariantCultureIgnoreCase);
            if (isTimeToStopLoop)
            {
                break;
            }

            var student = new Student(inputLine);
            Student.allStudents.Add(student);
        }

        Console.WriteLine(StudentGroup.allStudents.Count);
    }
}

