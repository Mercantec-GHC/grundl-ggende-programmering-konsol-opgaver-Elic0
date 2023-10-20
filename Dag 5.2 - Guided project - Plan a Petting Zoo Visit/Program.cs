using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, AnimalInfo> animalInfo = new Dictionary<string, AnimalInfo>
        {
            { "alpacas", new AnimalInfo("Alpaca", "Land", 150, 5.5, 3) },
            { "capybaras", new AnimalInfo("Capybara", "Land", 150, 4.4, 2) },
            { "chickens", new AnimalInfo("Chicken", "Land", 5, 1, 1) },
            { "ducks", new AnimalInfo("Duck", "Land", 3, 1.5, 1) },
            { "emus", new AnimalInfo("Emu", "Land", 110, 6.6, 6) },
            { "geese", new AnimalInfo("Goose", "Land", 12, 2.6, 2) },
            { "goats", new AnimalInfo("Goat", "Land", 120, 4, 2.5) },
            { "iguanas", new AnimalInfo("Iguana", "Land", 9, 4, 1.2) },
            { "kangaroos", new AnimalInfo("Kangaroo", "Land", 200, 8.5, 5) },
            { "lemurs", new AnimalInfo("Lemur", "Land", 5, 1.5, 1) },
            { "llamas", new AnimalInfo("Llama", "Land", 250, 6, 6) },
            { "macaws", new AnimalInfo("Macaw", "Land", 2, 0.6, 0.2) },
            { "ostriches", new AnimalInfo("Ostrich", "Land", 220, 9, 8) },
            { "pigs", new AnimalInfo("Pig", "Land", 300, 4, 2) },
            { "ponies", new AnimalInfo("Pony", "Land", 500, 4, 4) },
            { "rabbits", new AnimalInfo("Rabbit", "Land", 2, 1, 0.4) },
            { "sheep", new AnimalInfo("Sheep", "Land", 100, 4, 3) },
            { "tortoises", new AnimalInfo("Tortoise", "Sea", 200, 2, 0.3) },
        };

        Console.WriteLine("Welcome to the Pet Information Menu!");
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Land Animals");
        Console.WriteLine("2. Sea Animals");
        Console.WriteLine("0. Exit");

        int firstChoice;
        do
        {
            Console.Write("Enter the number of your choice: ");
            if (int.TryParse(Console.ReadLine(), out firstChoice))
            {
                switch (firstChoice)
                {
                    case 1:
                        ShowAnimalOptions("Land Animals", animalInfo, "Land");
                        break;
                    case 2:
                        ShowAnimalOptions("Sea Animals", animalInfo, "Sea");
                        break;
                    case 0:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        } while (firstChoice != 0);
    }

    static void ShowAnimalOptions(string category, Dictionary<string, AnimalInfo> animalInfo, string type)
    {
        Console.WriteLine(category);
        Console.WriteLine("Select an animal:");
        List<string> animalsInCategory = new List<string>();

        foreach (var animal in animalInfo)
        {
            if (animal.Value.Type == type)
            {
                animalsInCategory.Add(animal.Key);
                Console.WriteLine($"{animalsInCategory.Count}. {animal.Value.Name}");
            }
        }

        Console.WriteLine("0. Back");

        int secondChoice;
        do
        {
            Console.Write("Enter the number of your choice: ");
            if (int.TryParse(Console.ReadLine(), out secondChoice))
            {
                if (secondChoice >= 1 && secondChoice <= animalsInCategory.Count)
                {
                    string selectedAnimalName = animalsInCategory[secondChoice - 1];
                    DisplayAnimalInfo(animalInfo[selectedAnimalName]);
                }
                else if (secondChoice == 0)
                {
                    Console.WriteLine("Returning to the previous menu.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        } while (secondChoice != 0);
    }

    static void DisplayAnimalInfo(AnimalInfo animal)
    {
        Console.WriteLine($"Name: {animal.Name}");
        Console.WriteLine($"Type: {animal.Type}");
        Console.WriteLine($"Average Weight: {animal.AverageWeight} kg");
        Console.WriteLine($"Average Length: {animal.AverageLength} meters");
        Console.WriteLine($"Average Height: {animal.AverageHeight} meters");
    }
}

class AnimalInfo
{
    public string Name { get; set; }
    public string Type { get; set; }
    public double AverageWeight { get; set; }
    public double AverageLength { get; set; }
    public double AverageHeight { get; set; }

    public AnimalInfo(string name, string type, double weight, double length, double height)
    {
        Name = name;
        Type = type;
        AverageWeight = weight;
        AverageLength = length;
        AverageHeight = height;
    }
}
