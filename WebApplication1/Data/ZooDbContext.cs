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

        public DbSet<Animal> Animals => Set<Animal>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Enclosure> Enclosures => Set<Enclosure>();
        public DbSet<Zoo> Zoos => Set<Zoo>();

        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        base.OnModelCreating(modelBuilder);

        //        // --- 1. Categories seed ---
        //        var categories = new List<Category>
        //{
        //    new Category { Id = 1, Name = "Mammals" },
        //    new Category { Id = 2, Name = "Birds" },
        //    new Category { Id = 3, Name = "Reptiles" },
        //    new Category { Id = 4, Name = "Aquatic" }
        //};
        //        modelBuilder.Entity<Category>().HasData(categories);

        //        // --- 2. Enclosures seed ---
        //        var enclosures = new List<Enclosure>
        //{
        //    new Enclosure { Id = 1, Name = "Savannah", Climate = Climate.Temperate, HabitatType = HabitatType.Grassland, SecurityLevel = SecurityLevel.Medium, Size = 500 },
        //    new Enclosure { Id = 2, Name = "Tropical Forest", Climate = Climate.Tropical, HabitatType = HabitatType.Forest, SecurityLevel = SecurityLevel.High, Size = 300 },
        //    new Enclosure { Id = 3, Name = "Aquarium", Climate = Climate.Temperate, HabitatType = HabitatType.Aquatic, SecurityLevel = SecurityLevel.Low, Size = 200 }
        //};
        //        modelBuilder.Entity<Enclosure>().HasData(enclosures);

        //        // --- 3. Animals seed met Bogus ---
        //        var faker = new Bogus.Faker<Animal>()
        //            .RuleFor(a => a.Id, f => f.IndexFaker + 1) // automatisch ID
        //            .RuleFor(a => a.Name, f => f.Name.FirstName())
        //            .RuleFor(a => a.Species, f => f.PickRandom(new[] { "Lion", "Elephant", "Parrot", "Shark", "Cobra" }))
        //            .RuleFor(a => a.Size, f => f.PickRandom<Size>())
        //            .RuleFor(a => a.DietaryClass, f => f.PickRandom<DietaryClass>())
        //            .RuleFor(a => a.ActivityPattern, f => f.PickRandom<ActivityPattern>())
        //            .RuleFor(a => a.SpaceRequirement, f => f.Random.Double(5, 100))
        //            .RuleFor(a => a.SecurityRequirement, f => f.PickRandom<SecurityLevel>())
        //            .RuleFor(a => a.CategoryId, f => f.PickRandom(categories).Id)
        //            .RuleFor(a => a.EnclosureId, f => f.PickRandom(enclosures).Id);

        //        var animals = faker.Generate(20); // 20 dieren
        //        modelBuilder.Entity<Animal>().HasData(animals);
        //    }

    }

}
