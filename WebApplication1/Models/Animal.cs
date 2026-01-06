using System.Drawing;

namespace WebApplication1.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;

        public SizeEnum Size { get; set; }
        public Diet DietaryClass { get; set; }
        public Activity ActivityPattern { get; set; }
        public string? Prey { get; set; }
        public double SpaceRequirement { get; set; }
        public SecurityLevel SecurityRequirement { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? EnclosureId { get; set; }
        public Enclosure? Enclosure { get; set; }

        public enum SizeEnum
        {
            Microscopic,
            VerySmall,
            Small,
            Medium,
            Large,
            VeryLarge
        }

        public enum Diet
        {
            Carnivore,
            Herbivore,
            Omnivore,
            Insectivore,
            Piscivore
        }

        public enum Activity
        {
            Diurnal,
            Nocturnal,
            Cathemeral
        }

    }
}
