using System;
using System.Collections.Generic;
using System.IO;

public class FinanceManager
{
    private string filePath = "data.csv";
    public List<Transaction> Transactions { get; private set; }

    public FinanceManager()
    {
        Transactions = new List<Transaction>();
        LoadFromFile();
    }

    public void AddTransaction(Transaction t)
    {
        Transactions.Add(t);
        SaveToFile(t); // append new record
    }

    public void ShowHistory()
    {
        Console.WriteLine("\n--- Transaction History ---");
        foreach (var t in Transactions)
        {
            Console.WriteLine($"{t.Date.ToShortDateString()} | {t.Type,-7} | {t.Description,-15} | ${t.Amount:F2}");
        }
    }

    public void ShowBalance()
    {
        double income = 0, expense = 0;
        foreach (var t in Transactions)
        {
            if (t.Type == "Income") income += t.Amount;
            else expense += t.Amount;
        }

        Console.WriteLine($"\nTotal Income:  ${income:F2}");
        Console.WriteLine($"Total Expense: ${expense:F2}");
        Console.WriteLine($"Balance:       ${income - expense:F2}");
    }

    private void SaveToFile(Transaction t)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{t.Type},{t.Description},{t.Amount},{t.Date}");
        }
    }

    private void LoadFromFile()
    {
        if (!File.Exists(filePath)) return;

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 4)
            {
                Transaction t = new Transaction
                {
                    Type = parts[0],
                    Description = parts[1],
                    Amount = double.Parse(parts[2]),
                    Date = DateTime.Parse(parts[3])
                };
                Transactions.Add(t);
            }
        }
    }
}
