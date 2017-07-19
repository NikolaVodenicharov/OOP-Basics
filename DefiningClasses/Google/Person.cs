namespace Google
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        public string name;
        public string company;
        public string car;
        public List<string> pokemons;
        public List<string> children;
        public List<string> parents;

        public Person(string name)
        {
            this.name = name;
            this.children = new List<string>();
            this.parents = new List<string>();
            this.pokemons = new List<string>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.name);

            sb.AppendLine("Company:");
            if (this.company != null)
            {
                sb.AppendLine(this.company);
            }

            sb.AppendLine("Car:");
            if (this.car != null)
            {
                sb.AppendLine(this.car);
            }

            sb.AppendLine("Pokemon:");
            if (this.pokemons.Count > 0)
            {
                sb.AppendLine(string.Join(Environment.NewLine, this.pokemons));
            }

            sb.AppendLine("Parents:");
            if (this.parents.Count > 0)
            {
                sb.AppendLine(string.Join(Environment.NewLine, this.parents));
            }

            sb.AppendLine("Children:");
            if (this.children.Count > 0)
            {
                sb.Append(string.Join(Environment.NewLine, this.children));
            }

            return sb.ToString().Trim();
        }
    }
}
