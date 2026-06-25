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

decimal Budget=0;
decimal Amount = 0;
bool valid = false;

switch (choice)
{
    case 1:
        AddExpense(ref Budget, ref Amount, ref valid);
        break;

    case 2:
        ViewSummary(Budget, Amount);
        break;

    case 3:
        SetBudget(ref Budget, ref valid);
        break;

    case 4:
        Console.WriteLine("You are logged out of your Account");
        break;
    default:
        Console.WriteLine("Invalid option");
        break;
}

static void AddExpense(ref decimal budget, ref decimal amount, ref bool valid)
{
    try
    {
        Console.WriteLine("Description: ");
        string description = Console.ReadLine();

        Console.WriteLine("Amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out amount))
        {
            Console.WriteLine("Amount must be a number");
            return;
        }

        amount = ValidateAmount(amount);

        Console.WriteLine("Category [Food/Transport/Utilities/Entertainment/Other]: ");
        string categoryInput = Console.ReadLine();
        string category = NormalizeCategory(categoryInput) ?? "Other";

        Console.WriteLine("Date (blank = today): ");
        string dateInput = Console.ReadLine();

        DateTime date;
        if (!DateTime.TryParse(dateInput, out date))
        {
            date = DateTime.Today;
        }

        Console.WriteLine("Note (optional): ");
        string note = Console.ReadLine();

        Console.WriteLine("Size band: " + ClassifyAmount(amount));

    }
    catch (Exception ex)
    {

        throw new Exception("something went wrong");
    }
    finally
    {
        Console.WriteLine("Expense recorded successfully.");
    }

}

static void ViewSummary(decimal budget, decimal amount)
{
    Console.WriteLine("==============================");
    Console.WriteLine("View Summary");
    Console.WriteLine("==============================");

    if (budget <= 0)
    {
        Console.WriteLine("No budget has been set yet!");
        return;
    }

    decimal spent = amount;
    decimal remaining = budget - spent;

    Console.WriteLine($"Budget:    {FormatCurrency(budget)}");
    Console.WriteLine($"Spent:     {FormatCurrency(spent)}");
    Console.WriteLine($"Remaining: {FormatCurrency(remaining)} -> {BudgetStatus(remaining, budget)}");
}

static void SetBudget(ref decimal budget, ref bool valid)
{
    Console.WriteLine("Monthly budget: ");

    while (!valid)
    {
        if (!decimal.TryParse(Console.ReadLine(), out budget) || budget <= 0)
        {
            Console.WriteLine("please input a valid number");
            continue;
        }

        valid = true;
    }

    Console.WriteLine($"Budget set to {FormatCurrency(budget)}.");
    Console.WriteLine($"Budget: {FormatCurrency(budget)} remaining of {FormatCurrency(budget)} -> {BudgetStatus(budget, budget)}");
}