using System.Drawing;

namespace WebApplication1.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;

        public Size AnimalSize { get; set; }
        public DietaryClass DietClass { get; set; }
        public ActivityPattern Activity { get; set; }
        public bool IsAwake { get; set; }
        public double SpaceRequirement { get; set; }
        public SecurityLevel Security { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public int? EnclosureId { get; set; }
        public Enclosure? Enclosure { get; set; }

        public ICollection<Animal> Prey { get; set; } = new List<Animal>();
        public enum Size
        {
            Microscopic,
            VerySmall,
            Small,
            Medium,
            Large,
            VeryLarge
        }

        public enum DietaryClass
        {
            Carnivore,
            Herbivore,
            Omnivore,
            Insectivore,
            Piscivore
        }

        public enum ActivityPattern
        {
            Diurnal,
            Nocturnal,
            Cathemeral
        }

    }
}
