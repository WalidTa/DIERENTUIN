namespace WebApplication1.Models
{
    public class Enclosure
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public SecurityLevel SecurityLevel { get; set; }
        public double Size { get; set; }
        public HabitatEnum Habitat { get; set; }
        public ClimateEnum Climate { get; set; }

        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
        public enum HabitatEnum
        {
            Forest,
            Aquatic,
            Desert,
            Grassland
        }
        public enum ClimateEnum
        {
            Tropical,
            Temperate,
            Arctic
        }

    }
}
