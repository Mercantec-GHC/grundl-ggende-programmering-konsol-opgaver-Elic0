using System;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

int maxPets = 6;
string menuSelection = "";

string[,] ourAnimals = new string[maxPets, 8];
int nextAvailableIndex = 0;

bool exitRequested = false;

for (int i = nextAvailableIndex; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";

            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }
    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

    nextAvailableIndex = i + 1; // Increment the next available index
}

while (!exitRequested)
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Edit an animal's age");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Ensure animal ages and physical descriptions are complete");
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

            if (nextAvailableIndex >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                break;
            }

            // Variables
            int petCount = 0;
            string anotherPet = "y";
            

            while (nextAvailableIndex < maxPets && anotherPet == "y")
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
                nextAvailableIndex++;

                if (nextAvailableIndex < maxPets)
                {
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    anotherPet = Console.ReadLine()?.ToLower();
                }
            }

            if (nextAvailableIndex >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
            }

            break;
        case "3":
            Console.WriteLine("You selected: 3. Edit an animal's age");

            // Display the list of pets for editing
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != null)
                {
                    Console.WriteLine($"Pet {i + 1}: {ourAnimals[i, 3]} ({ourAnimals[i, 2].Replace("Age: ", "")} years old)");
                }
            }

            // Prompt the user to select a pet
            int petToEdit = -1;
            do
            {
                Console.WriteLine("Enter the number of the pet you want to edit (1, 2, 3, etc.) or type 'exit' to go back:");
                string petSelection = Console.ReadLine()?.ToLower();
                if (petSelection == "exit")
                {
                    break; // Exit editing
                }
                else if (int.TryParse(petSelection, out petToEdit) && petToEdit >= 1 && petToEdit <= maxPets)
                {
                    break; // Valid pet selection
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid pet number or type 'exit'.");
                }
            } while (true);

            if (petToEdit >= 1)
            {
                // User chose a pet to edit
                Console.WriteLine($"Editing {ourAnimals[petToEdit - 1, 3]}'s age (current age: {ourAnimals[petToEdit - 1, 2].Replace("Age: ", "")}).");

                // Prompt the user for the new age
                do
                {
                    Console.WriteLine("Enter the new age or type '?' if unknown:");
                    string newAge = Console.ReadLine();
                    if (newAge == "?")
                    {
                        ourAnimals[petToEdit - 1, 2] = "Age: ?";
                        break;
                    }
                    else if (int.TryParse(newAge, out int petAge) && petAge >= 0)
                    {
                        ourAnimals[petToEdit - 1, 2] = "Age: " + petAge;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid age or type '?' if unknown.");
                    }
                } while (true);

                Console.WriteLine("Age updated successfully.");
            }

            break;
        case "4":
            Console.WriteLine("You selected: 4. Ensure animal nicknames and personality descriptions are complete");
            break;
        case "5":
            Console.WriteLine("You selected: 5. Ensure animal ages and physical descriptions are complete");
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
