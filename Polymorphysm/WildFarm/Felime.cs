using System;

namespace WildFarm
{
    public abstract class Felime : Mammal
    {
        // Constructor
        public Felime(string name, string type, double weight,  string livingRegion) 
            : base(name, type, weight, livingRegion)
        {
        }
    }
}
