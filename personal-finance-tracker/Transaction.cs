using System;

public class Transaction
{
    public string Type { get; set; } // "Income" or "Expense"
    public string Description { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
}
