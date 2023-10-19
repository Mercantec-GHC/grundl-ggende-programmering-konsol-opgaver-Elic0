    using System;
    // #1 the ourAnimals array will store the following: 
    string animalSpecies = "";
    string animalID = "";
    string animalAge = "";
    string animalPhysicalDescription = "";
    string animalPersonalityDescription = "";
    string animalNickname = "";

    // #2 variables that support data entry
    int maxPets = 8;
    string readResult;
    string menuSelection = "";

    // #3 array used to store runtime data, there is no persisted data
    string[,] ourAnimals = new string[maxPets, 6];

    // #4 create sample data ourAnimals array entries
    for (int i = 0; i < maxPets; i++)
    {
        switch (i)
        {
            case 0:
                animalSpecies = "dog";
                animalID = "d1";
                animalAge = "2";
                animalPhysicalDescription = "medium-sized cream-colored female golden retriever weighing about 45 pounds. Housebroken.";
                animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. Gives lots of kisses.";
                animalNickname = "lola";
                break;

            case 1:
                animalSpecies = "dog";
                animalID = "d2";
                animalAge = "9";
                animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. Housebroken.";
                animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! Loves to lean-in and give doggy hugs.";
                animalNickname = "gus";
                break;

            case 2:
                animalSpecies = "cat";
                animalID = "c3";
                animalAge = "1";
                animalPhysicalDescription = "small white female weighing about 8 pounds. Litter box trained.";
                animalPersonalityDescription = "friendly";
                animalNickname = "snow";
                break;

            case 3:
                animalSpecies = "cat";
                animalID = "c4";
                animalAge = "3";
                animalPhysicalDescription = "Medium-sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
                animalPersonalityDescription = "A people-loving cat that likes to sit on your lap.";
                animalNickname = "Lion";
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
    }

    // #5 display the top-level menu options
    {
        // NOTE: the Console.Clear method is throwing an exception in debug session
        Console.Clear();

        Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
        Console.WriteLine(" 1. List all of our current pet information");
        Console.WriteLine(" 2. Display all dogs with a specified characteristic");
        Console.WriteLine(" 3. Display all cats with a specified characteristic");
        Console.WriteLine();
        Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

        readResult = Console.ReadLine();
        if (readResult != null)
        {
            menuSelection = readResult.ToLower();
        }
    // Use switch-case to process the selected menu option
    switch (menuSelection)
        {
            case "1":
                // List all pet info
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] != "ID #: ")
                    {
                        Console.WriteLine();
                        for (int j = 0; j < 6; j++)
                        {
                            Console.WriteLine(ourAnimals[i, j]);
                        }
                    }
                }
                Console.WriteLine("\nPress the Enter key to continue");
                readResult = Console.ReadLine();
                break;

            case "2":
                Console.WriteLine("Enter the characteristic you want to search for in dogs (e.g., 'friendly', 'housebroken'):");
                string characteristic = Console.ReadLine().ToLower();

                Console.WriteLine("Dogs with the specified characteristic:");
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] != "ID #: " && ourAnimals[i, 1].ToLower().Contains("species: dog"))
                    {
                        string personalityDescription = ourAnimals[i, 5].ToLower();
                        if (personalityDescription.Contains(characteristic))
                        {
                            Console.WriteLine();
                            for (int j = 0; j < 6; j++)
                            {
                                Console.WriteLine(ourAnimals[i, j]);
                            }
                        }
                    }
                }
                Console.WriteLine("\nPress the Enter key to continue.");
                readResult = Console.ReadLine();
                break;

            case "3":
                Console.WriteLine("Enter the characteristic you want to search for in cats (e.g., 'friendly', 'litter box trained'):");
                string catCharacteristic = Console.ReadLine().ToLower();

                Console.WriteLine("Cats with the specified characteristic:");
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] != "ID #: " && ourAnimals[i, 1].ToLower().Contains("species: cat"))
                    {
                        string personalityDescription = ourAnimals[i, 5].ToLower();
                        if (personalityDescription.Contains(catCharacteristic))
                        {
                            Console.WriteLine();
                            for (int j = 0; j < 6; j++)
                            {
                                Console.WriteLine(ourAnimals[i, j]);
                            }
                        }
                    }
                }
                Console.WriteLine("\nPress the Enter key to continue.");
                readResult = Console.ReadLine();
                break;
        }
    } while (menuSelection != "exit") ;
