public abstract class Character
{
  public UInt64 Id { get; set; }
  public string? Name { get; set; }
  public string? Description { get; set; }

  public string getName()
  {
    return $"{Name}";
  }
    public string getDescription()
  {
    return $"{Description}";
  }

    public int getId()
  {
    return (int)Id;
  }
  public virtual string Display()
  {
    return $"Id: {Id}\nName: {Name}\nDescription: {Description}\n";
  }
}