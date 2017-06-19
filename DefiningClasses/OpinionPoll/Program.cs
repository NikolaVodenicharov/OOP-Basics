using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpinionPoll
{
    public class Person
    {
        private string name;
        private int age;

        public Person (string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return this.name; }
        }
        // public string Name => this.name;

        public int Age
        {
            get { return this.age; }
        }
        // public int Age => this.age;

    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            List<Person> listOfPersons = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string personName = personData[0];
                int personAge = int.Parse(personData[1]);

                Person person = new Person(personName, personAge);

                listOfPersons.Add(person);
            }

            listOfPersons
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p =>{Console.WriteLine($"{p.Name} - {p.Age}");});

        }
    }
}
