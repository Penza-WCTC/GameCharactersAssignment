using System.Text.Json;
using NLog;
string path = Directory.GetCurrentDirectory() + "//nlog.config";

// create instance of Logger
var logger = LogManager.Setup().LoadConfigurationFromFile(path).GetCurrentClassLogger();

logger.Info("Program started");

//Make sure that 1 list is selected.
string listSelected;

while (true)
{

    Console.WriteLine("1) Access Mario");
    Console.WriteLine("2) Access Donkey Kong");
    Console.WriteLine("3) Access Street Fighter 2");

    string? characterChoice = Console.ReadLine();
    logger.Info("User choice: {Choice}", characterChoice);


    if (characterChoice == "1")
    {
        string marioFileName = "mario.json";
        List<Mario> marios = JsonSerializer.Deserialize<List<Mario>>(File.ReadAllText(marioFileName))!;
        listSelected = "Mario";
        break;
    }

    else if (characterChoice == "2")
    {
        string dkFileName = "dk.json";
        List<DonkeyKong> donkeyKongs = JsonSerializer.Deserialize<List<DonkeyKong>>(File.ReadAllText(dkFileName))!;
        listSelected = "DonkeyKong";
        break;
    }

    else if (characterChoice == "3")
    {
        string sf2FileName = "sf2.json";
        List<StreetFighter2> streetFighter2s = JsonSerializer.Deserialize<List<StreetFighter2>>(File.ReadAllText(sf2FileName))!;
        listSelected = "StreetFighter2";
        break;
    }

    else
    {
        Console.WriteLine("Select from one of the provided lists");
    }
}

do
{
    // display choices to user
    Console.WriteLine("1) Display the "+ listSelected +" Characters");
    Console.WriteLine("2) Add a "+listSelected+" Character");
    Console.WriteLine("3) Remove a "+listSelected+" Character");
    Console.WriteLine("Enter to quit");

    // input selection
    string? choice = Console.ReadLine();
    logger.Info("User choice: {Choice}", choice);

    if (choice == "1")
    {
        // Display Mario Characters
    }
    else if (choice == "2")
    {
        // Add Mario Character
    }
    else if (choice == "3")
    {
        // Remove Mario Character
    }
    else if (string.IsNullOrEmpty(choice))
    {
        break;
    }
    else
    {
        logger.Info("Invalid choice");
    }
} while (true);

logger.Info("Program ended");

logger.Info("Program ended");