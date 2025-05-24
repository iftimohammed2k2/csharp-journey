using System;

class Program
{
    static void Main()
    {
        string[] petIDs = { "c1", "c2", "c3", "c4", "c5" };
        string[] petNicknames = { "Fluffy", "", null, "", "Max" };
        string[] petPersonalityDescriptions = { "playful", "", null, "", "curious and energetic" };

        while (true)
        {
            Console.WriteLine("Enter menu option (1-5):");
            string menuOption = Console.ReadLine();

            if (menuOption == "4")
            {
                for (int i = 0; i < petIDs.Length; i++)
                {
                    if (string.IsNullOrEmpty(petIDs[i]))
                    {
                        continue; // Skip pets with default ID
                    }

                    // Nickname
                    while (string.IsNullOrEmpty(petNicknames[i]))
                    {
                        Console.WriteLine($"Enter a nickname for ID #: {petIDs[i]}");
                        string inputNickname = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(inputNickname))
                        {
                            petNicknames[i] = inputNickname;
                        }
                    }

                    // Personality
                    while (string.IsNullOrEmpty(petPersonalityDescriptions[i]))
                    {
                        Console.WriteLine($"Enter a personality description for ID #: {petIDs[i]} (likes or dislikes, tricks, energy level)");
                        string inputPersonality = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(inputPersonality))
                        {
                            petPersonalityDescriptions[i] = inputPersonality;
                        }
                    }
                }

                Console.WriteLine("Nickname and personality description fields are complete for all of our friends. Press the Enter key to continue");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("That menu option is not handled in this demo.");
            }
        }
    }
}
