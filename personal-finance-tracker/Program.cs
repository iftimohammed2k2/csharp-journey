using System;

class Program
{
    static void Main()
    {
        FinanceManager manager = new FinanceManager();
        int choice;

        do
        {
            Console.WriteLine("\n=== Personal Finance Tracker ===");
            Console.WriteLine("1. Add Income");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. View Transactions");
            Console.WriteLine("4. View Balance");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            
            if (!int.TryParse(Console.ReadLine(), out choice)) continue;

            switch (choice)
            {
                case 1:
                    AddTransaction(manager, "Income");
                    break;
                case 2:
                    AddTransaction(manager, "Expense");
                    break;
                case 3:
                    manager.ShowHistory();
                    break;
                case 4:
                    manager.ShowBalance();
                    break;
            }

        } while (choice != 0);

        Console.WriteLine("Goodbye!");
    }

    static void AddTransaction(FinanceManager manager, string type)
    {
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();

        Console.Write("Enter amount: ");
        if (!double.TryParse(Console.ReadLine(), out double amount)) {
            Console.WriteLine("Invalid amount.");
            return;
        }

        Transaction t = new Transaction
        {
            Type = type,
            Description = desc,
            Amount = amount,
            Date = DateTime.Now
        };

        manager.AddTransaction(t);
        Console.WriteLine($"{type} recorded.");
    }
}
