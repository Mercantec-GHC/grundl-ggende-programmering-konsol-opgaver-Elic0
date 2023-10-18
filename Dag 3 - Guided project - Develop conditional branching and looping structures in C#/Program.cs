using System;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

int maxPets = 4;
string menuSelection = "";

string[,] ourAnimals = new string[maxPets, 6];

bool exitRequested = false;

while (!exitRequested)
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal's age");
    Console.WriteLine(" 6. Edit an animal's personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine(" 9. Exit the program");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number:");

    menuSelection = Console.ReadLine()?.ToLower();

    switch (menuSelection)
    {
        case "1":
            Console.WriteLine("You selected: 1. List all of our current pet information");
            // Placeholder for option 1 logic:
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != null)
                {
                    Console.WriteLine("Pet " + (i + 1) + ":");
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            break;
        case "2":
            Console.WriteLine("You selected: 2. Add a new animal friend to the ourAnimals array");

            // Variables
            int petCount = 0;
            string anotherPet = "y";

            while (petCount < maxPets && anotherPet == "y")
            {
                Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                animalSpecies = Console.ReadLine()?.ToLower();

                // Build the animal ID
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1);

                Console.WriteLine("Enter the pet's age or enter ? if unknown");
                animalAge = Console.ReadLine();

                Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                animalPhysicalDescription = Console.ReadLine();

                Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                animalPersonalityDescription = Console.ReadLine();

                Console.WriteLine("Enter a nickname for the pet");
                animalNickname = Console.ReadLine();

                // Store the pet information in the ourAnimals array
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                // Increment petCount
                petCount++;

                if (petCount < maxPets)
                {
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    anotherPet = Console.ReadLine()?.ToLower();
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
            }

            break;
        case "3":
            Console.WriteLine("You selected: 3. Ensure animal ages and physical descriptions are complete");
            break;
        case "4":
            Console.WriteLine("You selected: 4. Ensure animal nicknames and personality descriptions are complete");
            break;
        case "5":
            Console.WriteLine("You selected: 5. Edit an animal's age");
            break;
        case "6":
            Console.WriteLine("You selected: 6. Edit an animal's personality description");
            break;
        case "7":
            Console.WriteLine("You selected: 7. Display all cats with a specified characteristic");
            break;
        case "8":
            Console.WriteLine("You selected: 8. Display all dogs with a specified characteristic");
            break;
        case "9":
            Console.WriteLine("Exiting the program.");
            exitRequested = true;
            break;
        default:
            Console.WriteLine("Invalid selection. Please enter a valid option.");
            break;
    }

    if (!exitRequested)
    {
        Console.WriteLine("Press the Enter key to continue");
        Console.ReadLine();
    }
}
