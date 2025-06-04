using System;
using Models;
using Controllers;

class Program
{
    static void Main(string[] args)
    {
        UserController controller = new UserController();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Simple REST API Simulator ---");
            Console.WriteLine("1. GET /users");
            Console.WriteLine("2. GET /users/{id}");
            Console.WriteLine("3. POST /users");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    var allUsers = controller.GetAllUsers();
                    if (allUsers.Count == 0)
                        Console.WriteLine("[]");
                    else
                        allUsers.ForEach(u => Console.WriteLine(u));
                    break;

                case "2":
                    Console.Write("Enter user ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var user = controller.GetUserById(id);
                    if (user != null)
                        Console.WriteLine(user);
                    else
                        Console.WriteLine($"User with ID {id} not found.");
                    break;

                case "3":
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter email: ");
                    string email = Console.ReadLine();
                    var newUser = controller.CreateUser(name, email);
                    Console.WriteLine($"User created: {newUser}");
                    break;

                case "0":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

