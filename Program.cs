using System.Text.Json;
using NLog;
string path = Directory.GetCurrentDirectory() + "//nlog.config";

// create instance of Logger
var logger = LogManager.Setup().LoadConfigurationFromFile(path).GetCurrentClassLogger();

logger.Info("Program started");

// deserialize mario json from file into List<Mario>
string marioFileName = "mario.json";
List<Mario> marios = JsonSerializer.Deserialize<List<Mario>>(File.ReadAllText(marioFileName))!;

string dkFileName = "dk.json";
List<DonkeyKong> donkeyKongs = JsonSerializer.Deserialize<List<DonkeyKong>>(File.ReadAllText(dkFileName))!;

string sf2FileName = "sf2.json";
List<StreetFighter2> streetFighter2s = JsonSerializer.Deserialize<List<StreetFighter2>>(File.ReadAllText(sf2FileName))!;

logger.Info("Program ended");