using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example
{
    class Dog
    {
        private string name;
        private int dogAge;

        public Dog(int dogAge)
        {
            this.dogAge = dogAge;
        }

        public int DogAge
        {
            get { return this.dogAge; }
            private set { value = this.dogAge; }
        }

        private int humanAge;
        private bool isMale;

        public void Walk()
        {
            Console.WriteLine("distance++");
        }

        public void Bark()
        {
            Console.WriteLine("Bark");
        }
    }
}
