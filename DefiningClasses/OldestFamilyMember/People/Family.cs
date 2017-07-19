namespace OldestFamilyMember.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            this.familyMembers = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.familyMembers.Add(member);
        }

        public string GetOldestMember()
        {
            Person oldest = this.familyMembers.OrderByDescending(x => x.age).First();
            string oldestMember= $"{oldest.name} {oldest.age}";

            return oldestMember;
        }
    }
}
