namespace OldestFamilyMember
{
    using People;
    using System;
    using System.Reflection;

    public class OldestFamilyMemberExecution
    {
        public static void Main()
        {
            var family = new Family();
            var inputLineNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLineNumber; i++)
            {
                var inputLine = Console.ReadLine().Split();

                family.AddMember(
                    new Person(
                        inputLine[0],
                        int.Parse(inputLine[1])));
            }

            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            Console.WriteLine(family.GetOldestMember()); 
        }
    }
}
