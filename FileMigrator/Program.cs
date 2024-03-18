// See https://aka.ms/new-console-template for more information
using FileMigrator.Controllers;
using FileMigrator.Models;

bool exitRequested = false;

string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
var filenameToParse = "ItemsWithComas.txt";// "ItemsWithPipes.txt" ;"ItemsWithSemicolon.txt";"ItemsWithSlash.txt";
string fileDirectory = Path.Combine(projectDirectory, "FilesToParse", filenameToParse);
List<ItemModel> items = new();

Console.WriteLine($"File directory: {fileDirectory}");
while (!exitRequested)
{
    Console.Clear();

    Console.WriteLine("Menu:");
    Console.WriteLine("1. Change format of migration");
    Console.WriteLine("2. Migrate File");
    Console.WriteLine("3. Search item by name");
    Console.WriteLine("4. Exit");
    Console.WriteLine();
    Console.WriteLine($"Current Selected format to migrate: {FormatController.GetSelectedFormat()}");

    int choice = GetMenuChoice(1, 4);

    switch (choice)
    {
        case 1:
            FormatController.ChangeFormat();
            break;
        case 2:
            items = MigratorController.MigrateFile(fileDirectory, FormatController.GetSelectedFormat());
            break;
        case 3:
            ItemsController.SearchByItemName(items);
            break;
        case 4:
            exitRequested = true;
            break;
    }
}

static int GetMenuChoice(int min, int max)
{
    Console.Write($"Enter your choice ({min}-{max}): ");
    if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
    {
        return choice;
    }
    else
    {
        Console.WriteLine($"Invalid choice. Please enter a number between {min} and {max}.");
        return GetMenuChoice(min, max);
    }
}



