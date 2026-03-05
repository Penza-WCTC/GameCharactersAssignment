public class DonkeyKong : Character
{
  public string? Species;

  public override string Display()
  {
    return $"Id: {Id}\nName: {Name}\nDescription: {Description}\nSpecies: {string.Join(", ", Species)}\n";
  }
}