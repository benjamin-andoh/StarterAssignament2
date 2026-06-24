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

Console.WriteLine("*** Welcome to the Expense Tracker ***");
Console.WriteLine("Select an option from the Menu");
Console.WriteLine($"{"1", -10} {"Add Expenses", -30}");
Console.WriteLine($"{"2", -10} {"View Summary", -30}");
Console.WriteLine($"{"3", -10} {"Set monthly budget", -30}");
Console.WriteLine($"{"4", -10} {"Exit", -30}");
Console.WriteLine();

Dictionary<int, String> menu = new Dictionary<int, string>
{
    {1,"Add Expenses" },
    {2, "View Summary"},
    {3, "Set Monthly Budget"},
    {4, "exit" }
};

decimal choice = 0;
bool intake = false;

while (!intake)
{
    if (!decimal.TryParse(Console.ReadLine(), out choice)  || choice <= 0 || choice >= 4)
    {
        Console.WriteLine("Sorry select from the options on the menu");
        continue;
    }
    intake = true;
}

Console.WriteLine($"this is your chioce {choice}");






