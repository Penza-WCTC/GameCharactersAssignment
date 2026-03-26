public class Mario : Character
{
  public List<string> Alias { get; set; } = [];


  
  public void removeFromArray(string arg)
  {
    Alias.Remove(arg);
  }
  public void addToArray(string arg)
  {
    Alias.Add(arg);
  }

  public string getName()
  {
    return $"{Name}";
  }
    public string getDescription()
  {
    return $"{Description}";
  }
    public string getAlias() 
  {
    return $"{string.Join(", ", Alias)}";
  }
  
  public int getId()
  {
    return (int)Id;
  }
  public List<string> getRealAlias()
  {
    return Alias;
  }
  public override string Display()
  {
    return $"Id: {Id}\nName: {Name}\nDescription: {Description}\nAlias: {string.Join(", ", Alias)}\n";
  }
}