using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingConstructors
{
    class Person
    {
        public string name;
        public int age;

        Person()
        {
            this.name = "No name";
            this.age = 1;
        }

        Person(int age) : this()
        {
            this.age = age; 
        }

        Person(int age, string name) : this(age)
        {
            this.age = age;
            this.name = name;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
