using System;
using System.Collections.Generic;
using System.Threading;

class Dog
{
    public string Nickname { get; set; }
    public string Description { get; set; }
}

class Program
{
    static void Main()
    {
        // Sample dog list
        List<Dog> dogList = new List<Dog>
        {
            new Dog { Nickname = "lola", Description = "big golden retriever" },
            new Dog { Nickname = "max", Description = "small playful beagle" },
            new Dog { Nickname = "buddy", Description = "loyal golden labrador" }
        };

        Console.WriteLine("Welcome to the Contoso PetFriends app.");
        Console.WriteLine("Your main menu options are:");
        Console.WriteLine("  1. List all of our current pet information");
        Console.WriteLine("  2. Display all dogs with a specified characteristic");
        Console.Write("Enter your selection number (or type Exit to exit the program): ");
        string selection = Console.ReadLine();

        if (selection.ToLower() == "exit")
        {
            return;
        }
        else if (selection == "1")
        {
            Console.WriteLine("\nCurrent Dog List:");
            foreach (Dog dog in dogList)
            {
                Console.WriteLine($"Nickname: {dog.Nickname}, Description: {dog.Description}");
            }
        }
        else if (selection == "2")
        {
            Console.Write("Enter dog characteristics to search for separated by commas: ");
            string input = Console.ReadLine();
            string[] searchTerms = input.Split(',');

            // #4: Replace these with spinning icons
            string[] searchingIcons = { "|", "/", "-", "\\" }; // spinning effect

            // #5: Show searching animation with countdown
            foreach (string rawTerm in searchTerms)
            {
                string term = rawTerm.Trim();

                foreach (Dog dog in dogList)
                {
                    for (int count = 2; count >= 0; count--)
                    {
                        foreach (string icon in searchingIcons)
                        {
                            Console.Write($"\rsearching our dog Nickname: {dog.Nickname} for {term} {icon} {count}");
                            Thread.Sleep(200);
                        }
                    }

                    // If the term matches the dog's description, show result
                    if (dog.Description.Contains(term, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"\nDog '{dog.Nickname}' matches with: {term}");
                    }
                }
            }

            Console.WriteLine("\nSearch complete.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }
}
