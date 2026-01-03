using ZooManagement.Core.Enums;

namespace ZooManagement.Core.Entities;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;

    public Size Size { get; set; }
    public DietaryClass DietaryClass { get; set; }
    public ActivityPattern ActivityPattern { get; set; }
    public bool IsAwake { get; set; }
    public double SpaceRequirement { get; set; }
    public SecurityLevel SecurityRequirement { get; set; }

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public int? EnclosureId { get; set; }
    public Enclosure? Enclosure { get; set; }

    public ICollection<Animal> Prey { get; set; } = new List<Animal>();
}
