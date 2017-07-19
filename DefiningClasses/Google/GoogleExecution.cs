namespace Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GoogleExecution
    {
        public static void Main(string[] args)
        {
            var people = new List<Person>();

            while (true)
            {
                var inputLine = Console.ReadLine();
                bool stopLoop = inputLine.Equals("End", StringComparison.OrdinalIgnoreCase);
                if (stopLoop)
                {
                    break;
                }

                var splitLine = inputLine.Split();
                var name = splitLine[0];

                if (!people.Any(x => x.name == name))
                {
                    people.Add(new Person(name));
                }

                var person = people.Single(x => x.name == name);
                var command = splitLine[1];
                var skipTwo = string.Join(" ", splitLine.Skip(2));

                if (command.Equals("company", StringComparison.OrdinalIgnoreCase))
                {
                    var salary = double.Parse(splitLine[4]);
                    string stringedSalary = $"{salary:f2}";
                    splitLine[4] = stringedSalary;
                    person.company = string.Join(" ", splitLine.Skip(2));
                }
                else if (command.Equals("car", StringComparison.OrdinalIgnoreCase))
                {
                    person.car = skipTwo;
                }
                else if (command.Equals("pokemon", StringComparison.OrdinalIgnoreCase))
                {
                    person.pokemons.Add(skipTwo);
                }
                else if (command.Equals("parents", StringComparison.OrdinalIgnoreCase))
                {
                    person.parents.Add(skipTwo);
                }
                else if (command.Equals("children", StringComparison.OrdinalIgnoreCase))
                {
                    person.children.Add(skipTwo);
                }
            }

            var serchedPerson = Console.ReadLine();
            if (people.Any(x => x.name == serchedPerson))
            {
                Console.WriteLine(people.Single(x => x.name == serchedPerson));
            }
        }
    }
}
