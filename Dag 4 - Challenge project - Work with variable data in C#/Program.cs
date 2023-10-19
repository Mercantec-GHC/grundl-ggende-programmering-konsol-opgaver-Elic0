using System;

// ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// variables that support data entry
int maxPets = 8;
string readResult;
string menuSelection = "";
decimal decimalDonation = 0.00m;
string buyerName = "";
decimal bidAmount = 0.00m;

// array used to store runtime data
string[,] ourAnimals = new string[maxPets, 7];

// sample data ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "gus";
            suggestedDonation = "49.99";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "snow";
            suggestedDonation = "40.00";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "lion";
            suggestedDonation = "";

            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;

    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

    if (!decimal.TryParse(suggestedDonation, out decimalDonation))
    {
        decimalDonation = 20.00m; // if suggestedDonation NOT a number, default to 45.00
    }
    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
}

// top-level menu options
do
{
    // NOTE: the Console.Clear method is throwing an exception in debug sessions
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Display all dogs with a specified characteristic");
    Console.WriteLine(" 3. bid on a pet from our selection");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    // switch-case to process the selected menu option
    switch (menuSelection)
    {
        case "1":
            // list all pet info
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j].ToString());
                    }
                }
            }

            Console.WriteLine("\r\nPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        case "2":
            // #1 Display all dogs with a multiple search characteristics

            string dogCharacteristic = "";

            while (dogCharacteristic == "")
            {
                // #2 have user enter multiple comma separated characteristics to search for
                Console.WriteLine($"\r\nEnter one desired dog characteristic to search for");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    dogCharacteristic = readResult.ToLower().Trim();
                    Console.WriteLine();
                }
            }

            bool noMatchesDog = true;
            string dogDescription = "";

            // loop ourAnimals array to search for matching animals
            for (int i = 0; i < maxPets; i++)
            {

                if (ourAnimals[i, 1].Contains("dog"))
                {

                    // Search combined descriptions and report results
                    dogDescription = ourAnimals[i, 4] + "\r\n" + ourAnimals[i, 5];

                    for (int j = 5; j > -1; j--)
                    {
                        // #5 update "searching" message to show countdown 
                        Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                    }

                    // #3a iterate submitted characteristic terms and search description for each term

                    if (dogDescription.Contains(dogCharacteristic))
                    {
                        // #3b update message to reflect term 
                        // #3c set a flag "this dog" is a match
                        Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match!");

                        noMatchesDog = false;
                    }

                    // #3d if "this dog" is match write match message + dog description
                }
            }

            if (noMatchesDog)
            {
                Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristic);
            }

            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;
        case "3":
            // Display pet information
            Console.WriteLine("Pet Information:");
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j].ToString());
                    }
                }
            }

            Console.WriteLine("\r\nEnter the ID of the pet you want to bid on or type 'Exit' to exit:");
            readResult = Console.ReadLine();

            if (readResult.ToLower() == "exit")
            {
                break;
            }

            string selectedPetId = readResult;

            // Find the selected pet by ID
            int selectedPetIndex = -1;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0].Contains("ID #: " + selectedPetId))
                {
                    selectedPetIndex = i;
                    break;
                }
            }

            if (selectedPetIndex == -1)
            {
                Console.WriteLine("Pet not found. Please enter a valid ID.");
                break;
            }

            // Display pet information for the selected pet
            Console.WriteLine("\nSelected Pet Information:");
            for (int j = 0; j < 7; j++)
            {
                Console.WriteLine(ourAnimals[selectedPetIndex, j].ToString());
            }

            Console.WriteLine("\r\nEnter your name:");
            buyerName = Console.ReadLine();

            Console.WriteLine("Enter your bid amount:");
            readResult = Console.ReadLine();

            if (decimal.TryParse(readResult, out bidAmount))
            {
                if (bidAmount >= decimalDonation)
                {
                    Console.WriteLine($"Congratulations, {buyerName}! Your bid of {bidAmount:C2} is accepted.");
                    decimalDonation = bidAmount;
                    ourAnimals[selectedPetIndex, 6] = $"Current bid: {decimalDonation:C2}";
                }
                else
                {
                    Console.WriteLine($"Sorry, {buyerName}. Your bid of {bidAmount:C2} is too low.");
                }
            }
            else
            {
                Console.WriteLine("Invalid bid amount. Please enter a valid numeric value.");
            }
            Console.WriteLine("\nPress the Enter key to continue");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");
