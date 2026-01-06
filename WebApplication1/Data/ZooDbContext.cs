using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions<ZooDbContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Zoo> Zoos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationships
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Enclosure)
                .WithMany(e => e.Animals)
                .HasForeignKey(a => a.EnclosureId);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Animals)
                .HasForeignKey(a => a.CategoryId);

            // Seed data
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            // Categories
            var categories = new List<Category>
            {
                new() { Id = 1, Name = "Mammal" },
                new() { Id = 2, Name = "Bird" },
                new() { Id = 3, Name = "Reptile" }
            };
            var Species = new[]
            {
                "Lion",
                "Tiger",
                "Elephant",
                "Giraffe",
                "Zebra",
                "Wolf",
                "Bear",
                "Penguin",
                "Crocodile",
                "Eagle"
            };

            modelBuilder.Entity<Category>().HasData(categories);

            // Enclosures
            var enclosures = new List<Enclosure>
            {
                new()
                {
                    Id = 1,
                    Name = "Savannah Enclosure",
                    Size = 500,
                    SecurityLevel = SecurityLevel.Medium,
                    Habitat = Enclosure.HabitatEnum.Grassland,
                    Climate = Enclosure.ClimateEnum.Temperate
                },
                new()
                {
                    Id = 2,
                    Name = "Jungle Enclosure",
                    Size = 300,
                    SecurityLevel = SecurityLevel.High,
                    Habitat = Enclosure.HabitatEnum.Forest,
                    Climate = Enclosure.ClimateEnum.Tropical
                }
            };

            modelBuilder.Entity<Enclosure>().HasData(enclosures);

            // Faker (Bogus) for Animals
            var faker = new Faker("en");

            var animals = new List<Animal>();

            for (int i = 1; i <= 10; i++)
            {
                animals.Add(new Animal
                {
                    Id = i,
                    Name = faker.Name.FirstName(),
                    Species = faker.PickRandom(Species),
                    Size = faker.PickRandom<Animal.SizeEnum>(),
                    DietaryClass = faker.PickRandom<Animal.Diet>(),
                    ActivityPattern = faker.PickRandom<Animal.Activity>(),
                    SpaceRequirement = faker.Random.Double(10, 100),
                    SecurityRequirement = faker.PickRandom<SecurityLevel>(),
                    CategoryId = faker.PickRandom(1, 2, 3),
                    EnclosureId = faker.PickRandom(1, 2),
                    Prey = faker.Random.Bool(0.4f) ? faker.PickRandom(Species) : null
                });
            }

            modelBuilder.Entity<Animal>().HasData(animals);
        }
        public DbSet<WebApplication1.Models.Zoo> Zoo { get; set; } = default!;
    }
}