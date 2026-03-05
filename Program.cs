using System.Text.Json;
using NLog;
using System.Reflection;
using NLog.LayoutRenderers;
string path = Directory.GetCurrentDirectory() + "//nlog.config";

// create instance of Logger
var logger = LogManager.Setup().LoadConfigurationFromFile(path).GetCurrentClassLogger();

logger.Info("Program started");

//Make sure that 1 list is selected.
string listSelected;
string? characterChoice;
List<Mario?> marios = new List<Mario?> { null };
List<DonkeyKong?> donkeyKongs = new List<DonkeyKong?> { null };
List<StreetFighter2?> streetFighter2s = new List<StreetFighter2?> { null };
string marioFileName = "mario.json";
string dkFileName = "dk.json";
string sf2FileName = "sf2.json";

while (true)
{

    Console.WriteLine("1) Access Mario");
    Console.WriteLine("2) Access Donkey Kong");
    Console.WriteLine("3) Access Street Fighter 2");

    characterChoice = Console.ReadLine();
    logger.Info("User choice: {Choice}", characterChoice);

    if (characterChoice == "1")
    {
        // check if file exists
        if (File.Exists(marioFileName))
        {
            marios = JsonSerializer.Deserialize<List<Mario>>(File.ReadAllText(marioFileName))!;
            logger.Info($"File deserialized {marioFileName}");
        }
        listSelected = "Mario";
        break;
    }

    else if (characterChoice == "2")
    {
        // check if file exists
        if (File.Exists(dkFileName))
        {
            donkeyKongs = JsonSerializer.Deserialize<List<DonkeyKong>>(File.ReadAllText(dkFileName))!;
            logger.Info($"File deserialized {dkFileName}");
        }
        listSelected = "DonkeyKong";
        break;
    }

    else if (characterChoice == "3")
    {
        // check if file exists
        if (File.Exists(sf2FileName))
        {
            streetFighter2s = JsonSerializer.Deserialize<List<StreetFighter2>>(File.ReadAllText(sf2FileName))!;
            logger.Info($"File deserialized {sf2FileName}");
        }
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
    Console.WriteLine("1) Display the " + listSelected + " Characters");
    Console.WriteLine("2) Add a " + listSelected + " Character");
    Console.WriteLine("3) Remove a " + listSelected + " Character");
    Console.WriteLine("Enter to quit");

    // input selection
    string? choice = Console.ReadLine();
    logger.Info("User choice: {Choice}", choice);

    if (choice == "1")
    {
        if (characterChoice == "1")
        {
            foreach (var c in marios)
            {
                Console.WriteLine(c.Display());
            }
        }
        else if (characterChoice == "2")
        {
            foreach (var c in donkeyKongs)
            {
                Console.WriteLine(c.Display());
            }
        }
        else if (characterChoice == "3")
        {
            foreach (var c in streetFighter2s)
            {
                Console.WriteLine(c.Display());
            }
        }
    }
    else if (choice == "2")
    {
        if (characterChoice == "1")
        {
            Mario mario = new()
            {
                Id = marios.Count == 0 ? 1 : marios.Max(c => c.Id) + 1
            };
            InputCharacter(mario);
            // Add Character
            marios.Add(mario);
            File.WriteAllText(marioFileName, JsonSerializer.Serialize(marios));
            logger.Info($"Character added: {mario.Name}");
        }
        else if (characterChoice == "2")
        {
            DonkeyKong donkeyKong = new()
            {
                Id = donkeyKongs.Count == 0 ? 1 : donkeyKongs.Max(c => c.Id) + 1
            };
            InputCharacter(donkeyKong);
            // Add Character
            donkeyKongs.Add(donkeyKong);
            File.WriteAllText(dkFileName, JsonSerializer.Serialize(donkeyKongs));
            logger.Info($"Character added: {donkeyKong.Name}");
        }
        else if (characterChoice == "3")
        {
            StreetFighter2 streetFighter2 = new()
            {
                Id = streetFighter2s.Count == 0 ? 1 : streetFighter2s.Max(c => c.Id) + 1
            };
            InputCharacter(streetFighter2);
            // Add Character
            streetFighter2s.Add(streetFighter2);
            File.WriteAllText(sf2FileName, JsonSerializer.Serialize(streetFighter2s));
            logger.Info($"Character added: {streetFighter2.Name}");
        }
    }
    else if (choice == "3")
    {
        if (characterChoice == "1")
        {
            {
                // Remove Mario Character
                Console.WriteLine("Enter the Id of the character to remove:");
                if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
                {
                    Mario? character = marios.FirstOrDefault(c => c.Id == Id);
                    if (character == null)
                    {
                        logger.Error($"Character Id {Id} not found");
                    }
                    else
                    {
                        marios.Remove(character);
                        // serialize list<marioCharacter> into json file
                        File.WriteAllText(marioFileName, JsonSerializer.Serialize(marios));
                        logger.Info($"Character Id {Id} removed");
                    }
                }
                else
                {
                    logger.Error("Invalid Id");
                }
            }
        }
        else if (characterChoice == "2")
        {
            {
                // Remove Mario Character
                Console.WriteLine("Enter the Id of the character to remove:");
                if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
                {
                    DonkeyKong? character = donkeyKongs.FirstOrDefault(c => c.Id == Id);
                    if (character == null)
                    {
                        logger.Error($"Character Id {Id} not found");
                    }
                    else
                    {
                        donkeyKongs.Remove(character);
                        // serialize list<marioCharacter> into json file
                        File.WriteAllText(dkFileName, JsonSerializer.Serialize(donkeyKongs));
                        logger.Info($"Character Id {Id} removed");
                    }
                }
                else
                {
                    logger.Error("Invalid Id");
                }
            }
        }
        else if (characterChoice == "3")
        {
            {
                // Remove Mario Character
                Console.WriteLine("Enter the Id of the character to remove:");
                if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
                {
                    StreetFighter2? character = streetFighter2s.FirstOrDefault(c => c.Id == Id);
                    if (character == null)
                    {
                        logger.Error($"Character Id {Id} not found");
                    }
                    else
                    {
                        streetFighter2s.Remove(character);
                        // serialize list<marioCharacter> into json file
                        File.WriteAllText(sf2FileName, JsonSerializer.Serialize(streetFighter2s));
                        logger.Info($"Character Id {Id} removed");
                    }
                }
                else
                {
                    logger.Error("Invalid Id");
                }
            }
        }
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

static void InputCharacter(Character character)
{
    Type type = character.GetType();
    PropertyInfo[] properties = type.GetProperties();
    var props = properties.Where(p => p.Name != "Id");
    foreach (PropertyInfo prop in props)
    {
        if (prop.PropertyType == typeof(string))
        {
            Console.WriteLine($"Enter {prop.Name}:");
            prop.SetValue(character, Console.ReadLine());
        }
        else if (prop.PropertyType == typeof(List<string>))
        {
            List<string> list = [];
            do
            {
                Console.WriteLine($"Enter {prop.Name} or (enter) to quit:");
                string response = Console.ReadLine()!;
                if (string.IsNullOrEmpty(response))
                {
                    break;
                }
                list.Add(response);
            } while (true);
            prop.SetValue(character, list);
        }
    }
}