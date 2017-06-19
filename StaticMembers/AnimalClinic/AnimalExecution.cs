using System;
using System.Collections.Generic;
using System.Text;

public class Animal
{
    public string name;
    public string breed;
    public int ID;
    public string medicalCondition; // healed or rehabilitated

    public Animal (string name, string breed, string medicalCondition)
    {
        this.name = name;
        this.breed = breed;
        this.medicalCondition = medicalCondition;
        AnimalClinic.patientID += 1;
        this.ID = AnimalClinic.patientID;

        if (this.medicalCondition.Equals("heal", StringComparison.InvariantCultureIgnoreCase))
        {
            AnimalClinic.healedAnimalCount += 1;
        }
        else
        {
            AnimalClinic.rehabilitatedAnimalCount += 1;
        }
    }
}

public class AnimalClinic
{
    public static int patientID;
    public static int healedAnimalCount;
    public static int rehabilitatedAnimalCount;
}

class AnimalExecution
{
    static void Main()
    {
        var animals = new List<Animal>();

        while (true)
        {
            var inputLine = Console.ReadLine();

            var isTimeToStopLoop = inputLine.Equals("end", StringComparison.InvariantCultureIgnoreCase);
            if (isTimeToStopLoop)
            {
                break;
            }

            AddAnimal(animals, inputLine);
        }

        var searchedMedicalConditionAnimals = Console.ReadLine(); // healed or rehabilitated

        var answer = new StringBuilder();
        AddInfoToAnswer(animals, searchedMedicalConditionAnimals, answer);

        PrintAnswer(answer);
    }

    private static void PrintAnswer(StringBuilder answer)
    {
        Console.WriteLine(answer);
    }

    private static void AddInfoToAnswer(List<Animal> animals, string searchedMedicalConditionAnimals, StringBuilder answer)
    {
        foreach (var animal in animals)
        {
            if (animal.medicalCondition.Equals("heal", StringComparison.InvariantCultureIgnoreCase))
            {
                answer.AppendLine($"Patient {animal.ID}: [{animal.name} ({animal.breed})] has been healed!");
            }
            else
            {
                answer.AppendLine($"Patient {animal.ID}: [{animal.name} ({animal.breed})] has been rehabilitated!");
            }
        }

        answer.AppendLine($"Total healed animals: {AnimalClinic.healedAnimalCount}");
        answer.AppendLine($"Total rehabilitated animals: {AnimalClinic.rehabilitatedAnimalCount}");

        foreach (var animal in animals)
        {
            if (animal.medicalCondition.Equals(searchedMedicalConditionAnimals, StringComparison.InvariantCultureIgnoreCase))
            {
                answer.AppendLine($"{animal.name} {animal.breed}");
            }
        }
    }

    private static void AddAnimal(List<Animal> animals, string inputLine)
    {
        var splitedLine = inputLine.Split();

        animals.Add(new Animal(splitedLine[0],
                               splitedLine[1],
                               splitedLine[2]));
    }
}

