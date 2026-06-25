// =====================================================================
//  Program.cs  —  the interactive console UI for MyBudget (Assignment 1).
//  Target framework: .NET 10 (LTS), language C# 14.
//
//  >>> BUILD THE MENU-DRIVEN UI HERE (Modules 1-3). <<<
//
//  Once you have implemented BudgetRules.cs (so the unit tests pass), wire it
//  up to a console interface that meets the assignment brief:
//
//    * Print a banner (try a raw string literal).
//    * Loop a menu until the user exits, using a switch on the choice:
//        1) Add an expense   2) View summary   3) Set monthly budget   4) Exit
//    * Read and VALIDATE input, re-prompting on bad data (decimal.TryParse, BudgetRules.NormalizeCategory, a date parse, non-empty text).
//    * Keep running totals in simple variables (no collections / no classes).
//    * Use BudgetRules.ValidateAmount / ClassifyAmount / BudgetStatus /
//      FormatCurrency for all logic and formatting.
//    * Handle bad input with try / catch / finally and InvalidExpenseException.
//
//  See section 6 of the assignment brief for a sample run to aim for.
// =====================================================================

using ExpenseTracker;
using System.ComponentModel;
using static ExpenseTracker.BudgetRules;

string doubleLinePrint = "=====================================================================";

Console.WriteLine(doubleLinePrint);
Console.WriteLine("MyBudget Expense Tracker");
Console.WriteLine(doubleLinePrint);

Console.WriteLine($" 1) Add an expense   2) View summary   3) Set monthly budget   4) Exit");
Console.Write(">");

decimal choice = 0;
bool intake = false;

while (!intake)
{
    if (!decimal.TryParse(Console.ReadLine(), out choice) || choice <= 0 || choice >= 5)
    {
        Console.WriteLine("Sorry select from the options on the menu");
        continue;
    }
    intake = true;
}

string Description = "";

string Category = "";
DateTime WhatDate;
string Note = "";
string Recorded = "";
decimal Budget=0;
decimal Remaining;
decimal Amount = 0;
bool valid = false;

switch (choice)
{
    case 1:
        // Description 
        Console.WriteLine("Description: ");
        Console.ReadLine();

        // Amount 
        Console.WriteLine("Amount     : ");
        if (!decimal.TryParse(Console.ReadLine(), out Amount))
        {
            Console.WriteLine("Amount must be a number");
        }
        ;
        ValidateAmount(Amount);

        // category
        Console.WriteLine("Category    : [Food/Transport/Utilities/Entertainment/Other] ");
        
        NormalizeCategory(Category);

        // Date
        Console.WriteLine("Date (blank = today): ");
        if (!DateTime.TryParse( Console.ReadLine(), out WhatDate))
        {
            Console.WriteLine("enter a valid date");
        }
        //if (WhatDate.IsEmpty)
        //{
        //    WhatDate = DateTime.Today;
        //}
        //if (WhatDate )


        // Note
        Console.WriteLine("Note (optional): ");

        // Recorded
        Console.WriteLine("Recorded: ");

        // Size Band
        Console.WriteLine("Size band: ");

        // Budget
        Console.WriteLine("Budget: ");
        break;
    case 2:
        Console.WriteLine(doubleLinePrint);
        Console.WriteLine("View Summary");
        Console.WriteLine(doubleLinePrint);
        // budget
        if (Budget <= 0)
        {
            Console.WriteLine("No budget has been set yet!");
            break;
        }

        // total spent - remaining budget - Budget status
        decimal spent = Amount;
        decimal remainder = Budget - spent;
        Console.WriteLine($"Budget: {FormatCurrency(Budget)}");
        Console.WriteLine($"Spent:  {FormatCurrency(spent)}");
        Console.WriteLine($"Remaining: {FormatCurrency(remainder)} -> {BudgetStatus(remainder, Budget)}");
        

        break;
    case 3:

        Remaining = Budget;
        Console.WriteLine("Monthly budget: ");
        while (!valid) { 
            if (!decimal.TryParse(Console.ReadLine(), out Budget) || Budget <= 0 )
            {
                Console.WriteLine("pleas input a number");
                continue;
            };
            valid = true;
        }
        Console.WriteLine($"Budget set to {FormatCurrency(Budget)}.");
        Console.WriteLine($"Budget: {FormatCurrency(Remaining)} remaining of {Budget} -> {BudgetStatus(Remaining, Budget)}");
        break;
    default:
        break;
}

//Console.WriteLine($"this is your chioce {choice}");



