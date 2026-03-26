public class StreetFighter2 : Character
{
  public List<string> Moves { get; set; } = [];

  public void removeFromArray(string arg)
  {
    Moves.Remove(arg);
  }
  public void addToArray(string arg)
  {
    Moves.Add(arg);
  }

  public string getMoves()
  {
    return $"{string.Join(", ", Moves)}";
  }


  public List<string> getRealMoves()
  {
    return Moves;
  }
  public override string Display()
  {
    return $"Id: {Id}\nName: {Name}\nDescription: {Description}\nMoves: {string.Join(", ", Moves)}\n";
  }
}