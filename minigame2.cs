using System;
using System.Threading;

class Program
{
    static int windowWidth = Console.WindowWidth;
    static int windowHeight = Console.WindowHeight;

    static int playerX;
    static int playerY;

    static int foodX;
    static int foodY;

    static string[] states = { "@", "#", "$", "%", "(X_X)", "(^-^)", "('-')" };
    static string[] foods = { "O", "*", "+", "=", "#####" };

    static int playerStateIndex = 0;
    static int foodStateIndex = 0;

    static bool frozen = false;
    static int delay = 200;

    static int horizontalSpeedModifier = 0;

    static void Main(string[] args)
    {
        Setup();

        Console.SetCursorPosition(playerX, playerY);
        Console.Write(states[playerStateIndex]);

        DisplayFood();

        while (true)
        {
            if (WasResized())
            {
                Console.Clear();
                Console.WriteLine("Console was resized. Program exiting.");
                break;
            }

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (IsPlayerFrozen())
                {
                    Thread.Sleep(100);
                    continue;
                }

                if (IsSpeedBoostActive())
                    horizontalSpeedModifier = 3;
                else
                    horizontalSpeedModifier = 0;

                // FIXED: all arguments now positional (C# < 7.2 compatible)
                bool continueGame = Move(keyInfo.Key, true, horizontalSpeedModifier);

                if (!continueGame)
                    break;

                if (PlayerConsumedFood())
                {
                    EatFood();
                    DisplayFood();
                }
            }

            Thread.Sleep(delay);
        }
    }

    static void Setup()
    {
        Console.Clear();
        playerX = windowWidth / 2;
        playerY = windowHeight / 2;

        Random rand = new Random();
        foodX = rand.Next(0, windowWidth);
        foodY = rand.Next(0, windowHeight);
        foodStateIndex = rand.Next(0, foods.Length);
    }

    static bool WasResized()
    {
        if (Console.WindowWidth != windowWidth || Console.WindowHeight != windowHeight)
        {
            windowWidth = Console.WindowWidth;
            windowHeight = Console.WindowHeight;
            return true;
        }
        return false;
    }

    static bool PlayerConsumedFood()
    {
        return playerX == foodX && playerY == foodY;
    }

    static void DisplayFood()
    {
        Random rand = new Random();
        foodX = rand.Next(0, windowWidth);
        foodY = rand.Next(0, windowHeight);
        foodStateIndex = rand.Next(0, foods.Length);

        Console.SetCursorPosition(foodX, foodY);
        Console.Write(foods[foodStateIndex]);
    }

    static void EatFood()
    {
        if (foods[foodStateIndex] == "#####")
        {
            playerStateIndex = Array.IndexOf(states, "(X_X)");
            FreezePlayerTemporarily();
        }
        else
        {
            if (foodStateIndex < states.Length - 3)
                playerStateIndex = foodStateIndex;
            else
                playerStateIndex = 0;
        }

        Console.SetCursorPosition(playerX, playerY);
        Console.Write(states[playerStateIndex]);
    }

    static void FreezePlayerTemporarily()
    {
        frozen = true;
        new Thread(() =>
        {
            Thread.Sleep(3000);
            frozen = false;
            playerStateIndex = 0;
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(states[playerStateIndex]);
        }).Start();
    }

    static bool IsPlayerFrozen()
    {
        return frozen || states[playerStateIndex] == "(X_X)";
    }

    static bool IsSpeedBoostActive()
    {
        return states[playerStateIndex] == "(^-^)";
    }

    static bool Move(ConsoleKey key, bool terminateOnNondirectional, int horizontalSpeedMod)
    {
        if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow ||
            key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
        {
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(" ");

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    playerY = Math.Max(0, playerY - 1);
                    break;
                case ConsoleKey.DownArrow:
                    playerY = Math.Min(windowHeight - 1, playerY + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    playerX = Math.Max(0, playerX - (1 + horizontalSpeedMod));
                    break;
                case ConsoleKey.RightArrow:
                    playerX = Math.Min(windowWidth - 1, playerX + (1 + horizontalSpeedMod));
                    break;
            }

            Console.SetCursorPosition(playerX, playerY);
            Console.Write(states[playerStateIndex]);

            return true;
        }
        else
        {
            if (terminateOnNondirectional)
            {
                Console.Clear();
                Console.WriteLine("Non-directional key pressed. Program exiting.");
                return false;
            }
            return true;
        }
    }
}
