namespace ZooManagement.Core.Entities;

public class Zoo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Enclosure> Enclosures { get; set; } = new List<Enclosure>();
}
