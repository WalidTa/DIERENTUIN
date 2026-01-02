using ZooManagement.Core.Enums;

namespace ZooManagement.Core.Entities;

public class Enclosure
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public Climate Climate { get; set; }
    public HabitatType HabitatType { get; set; }
    public SecurityLevel SecurityLevel { get; set; }

    public double Size { get; set; }

    public ICollection<Animal> Animals { get; set; } = new List<Animal>();
}
