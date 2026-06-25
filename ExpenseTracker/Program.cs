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
    if (!decimal.TryParse(Console.ReadLine(), out choice) || choice <= 0 || choice >= 4)
    {
        Console.WriteLine("Sorry select from the options on the menu");
        continue;
    }
    intake = true;
}

string Description = "";
decimal Amount = 0;
string Category = "";
DateTime WhatDate = DateTime.Today;
string Note = "";
string Recorded = "";
Decimal Budget = 0;

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
        break;
    case 3:
        break;
    default:
        break;
}

Console.WriteLine($"this is your chioce {choice}");



