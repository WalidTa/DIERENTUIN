using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ZoosController : Controller
    {
        private readonly ZooDbContext _context;

        public ZoosController(ZooDbContext context)
        {
            _context = context;
        }

        // GET: Zoos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zoo.ToListAsync());
        }

        // GET: Zoos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zoo = await _context.Zoo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zoo == null)
            {
                return NotFound();
            }

            return View(zoo);
        }

        public async Task<IActionResult> Sunrise()
        {
            var animals = await _context.Animals
                .Include(a => a.Enclosure)
                .ToListAsync();

            var results = new List<string>();

            foreach (var animal in animals)
            {
                string status;
                switch (animal.ActivityPattern)
                {
                    case Animal.Activity.Diurnal:
                        animal.IsAwake = true;
                        status = $"{animal.Name} wakes up!";
                        break;
                    case Animal.Activity.Nocturnal:
                        animal.IsAwake = false;
                        status = $"{animal.Name} goes to sleep.";
                        break;
                    default:
                        animal.IsAwake = true;
                        status = $"{animal.Name} is active regardless, because it is Cathemeral.";
                        break;
                }

                _context.Update(animal);
                await _context.SaveChangesAsync();

                results.Add(status);
            }

            
            ViewData["ActionName"] = "Sunrise";
            return View("ActionResult", results);
        }

        public async Task<IActionResult> Sunset()
        {
            var animals = await _context.Animals
                .Include(a => a.Enclosure)
                .ToListAsync();

            var results = new List<string>();

            foreach (var animal in animals)
            {
                string status;
                switch (animal.ActivityPattern)
                {
                    case Animal.Activity.Nocturnal:
                        animal.IsAwake = true;
                        status = $"{animal.Name} wakes up!";
                        break;
                    case Animal.Activity.Diurnal:
                        animal.IsAwake = false;
                        status = $"{animal.Name} goes to sleep.";
                        break;
                    default:
                        animal.IsAwake = true;
                        status = $"{animal.Name} is active regardless, because it is Cathemeral.";
                        break;
                }
                _context.Update(animal);
                await _context.SaveChangesAsync();


                results.Add(status);
            }

            ViewData["ActionName"] = "Sunset";
            return View("ActionResult", results);
        }

        // Actions: Feeding Time for the entire Zoo
        public async Task<IActionResult> FeedingTime()
        {
            var animals = await _context.Animals
                .Include(a => a.Enclosure)
                .ToListAsync();

            if (!animals.Any())
            {
                ViewData["ActionName"] = "Feeding Time";
                return View("ActionResult", "No animals in the zoo.");
            }

            var results = new List<string>();
            foreach (var animal in animals)
            {
                string status;
                // Check if the animal has a specific prey
                if (!animal.IsAwake)
                {
                    status = $"{animal.Name} is asleep right now because the sun is {(animal.ActivityPattern == Animal.Activity.Nocturnal ? "up" : "down")}!";
                }
                else if (!string.IsNullOrEmpty(animal.Prey) && animal.IsAwake)
                {
                    status = $"{animal.Name} eats its prey: {animal.Prey}";
                }
                else
                {
                    // Default output based on dietary class
                    status = $"{animal.Name} is fed according to its diet: {animal.DietaryClass}.";
                }

                results.Add(status);
            }

            ViewData["ActionName"] = "Feeding Time at the Zoo";
            return View("ActionResult", results);
        }

        // Actions: Check Constraints for the entire Zoo
        public async Task<IActionResult> CheckConstraints()
        {
            var animals = await _context.Animals
                .Include(a => a.Enclosure)
                .ToListAsync();

            if (!animals.Any())
            {
                ViewData["ActionName"] = "Check Constraints";
                return View("ActionResult", "No animals in the zoo.");
            }

            var results = new List<string>();
            int totalHappyAnimals = 0;

            results.Add("=== Zoo-Wide Animal Constraint Check ===");
            results.Add("");

            foreach (var animal in animals)
            {
                results.Add($"--- {animal.Name} ({animal.Species}) ---");

                if (animal.Enclosure == null)
                {
                    results.Add($"{animal.Name} doesn't have an enclosure!");
                    results.Add("");
                    continue;
                }

                // Calculate space per animal in enclosure
                double availableSpace = animal.Enclosure.Size / animal.Enclosure.Animals.Count;
                bool hasEnoughSpace = availableSpace >= animal.SpaceRequirement;
                bool meetsSecurityRequirements = (int)animal.SecurityRequirement <= (int)animal.Enclosure.SecurityLevel;

                results.Add($"Enclosure: {animal.Enclosure.Name}");
                results.Add($"Space: Requires {animal.SpaceRequirement}, has {availableSpace:F2} - {(hasEnoughSpace ? " Sufficient" : " Insufficient")}");
                results.Add($"Security: Requires {animal.SecurityRequirement}, enclosure has {animal.Enclosure.SecurityLevel} - {(meetsSecurityRequirements ? " Met" : " Not met")}");

                // Determine mood based on constraints
                if (hasEnoughSpace && meetsSecurityRequirements)
                {
                    results.Add($"Status: {animal.Name} is happy! All constraints met!");
                    totalHappyAnimals++;
                }
                else if (hasEnoughSpace || meetsSecurityRequirements)
                {
                    results.Add($"Status: {animal.Name} is in a sad mood! {(hasEnoughSpace ? "Lacks security" : "Needs more space")}!");
                }
                else
                {
                    results.Add($"Status: {animal.Name} is very sad! Needs more space and security!");
                }

                results.Add("");
            }

            results.Add("=== Overall Zoo Health ===");
            results.Add($"Total Animals: {animals.Count}");
            results.Add($"Happy Animals: {totalHappyAnimals}");
            results.Add($"Unhappy Animals: {animals.Count - totalHappyAnimals}");
            results.Add($"Happiness Rate: {(animals.Count > 0 ? (totalHappyAnimals * 100.0 / animals.Count).ToString("F1") : "0")}%");

            ViewData["ActionName"] = "Zoo-Wide Constraint Check";
            return View("ActionResult", results);
        }

        // Auto-assign animals to enclosures based on requirements
        public async Task<IActionResult> AutoAssign()
        {
            try
            {
                var unassignedCount = await _context.Animals
                    .Where(a => a.EnclosureId == null)
                    .CountAsync();

                return View(unassignedCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AutoAssign GET: {ex.Message}");
                return View(0);
            }
        }

        // POST: Zoos/AutoAssign
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AutoAssign(string assignmentMode)
        {
            var results = new List<string>();

            if (assignmentMode == "fresh")
            {
                // Remove all existing enclosures and start from scratch
                var existingEnclosures = await _context.Enclosures.Include(e => e.Animals).ToListAsync();
                
                results.Add("=== Starting fresh ===");
                results.Add($"Removing {existingEnclosures.Count} existing enclosure(s)...");
                results.Add("");

                foreach (var enclosure in existingEnclosures)
                {
                    // Unassign all animals first
                    foreach (var animal in enclosure.Animals)
                    {
                        animal.EnclosureId = null;
                    }
                    _context.Enclosures.Remove(enclosure);
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                results.Add("=== Auto assigning ===");
                results.Add("");
            }

            // Get all animals that need assignment
            var unassignedAnimals = await _context.Animals
                .Include(a => a.Category)
                .Where(a => a.EnclosureId == null)
                .ToListAsync();

            if (!unassignedAnimals.Any())
            {
                results.Add("All animals are housed.");
                ViewData["ActionName"] = "Auto Assignment";
                return View("ActionResult", results);
            }

            results.Add($"automatically assigning {unassignedAnimals.Count} animal(s).");
            results.Add("");

            // Group animals by security requirement and category
            var animalGroups = unassignedAnimals
                .GroupBy(a => new { a.SecurityRequirement, Category = a.Category?.Name ?? "Uncategorized" })
                .ToList();

            int enclosuresCreated = 0;
            int animalsAssigned = 0;

            foreach (var group in animalGroups)
            {
                var groupAnimals = group.ToList();
                results.Add($"--- Processing {group.Key.Category} animals (Security: {group.Key.SecurityRequirement}) ---");
                results.Add($"Animals in group: {groupAnimals.Count}");

                if (assignmentMode == "complete")
                {
                    // Try to fit animals into existing enclosures first
                    var existingEnclosures = await _context.Enclosures
                        .Include(e => e.Animals)
                        .Where(e => (int)e.SecurityLevel >= (int)group.Key.SecurityRequirement)
                        .ToListAsync();

                    foreach (var enclosure in existingEnclosures)
                    {
                        if (!groupAnimals.Any()) break;

                        var remainingAnimals = new List<Animal>(groupAnimals);
                        foreach (var animal in remainingAnimals)
                        {
                            // Check if animal fits in available space
                            double currentUsedSpace = enclosure.Animals.Sum(a => a.SpaceRequirement);
                            double availableSpace = enclosure.Size - currentUsedSpace;

                            if (availableSpace >= animal.SpaceRequirement)
                            {
                                animal.EnclosureId = enclosure.Id;
                                groupAnimals.Remove(animal);
                                animalsAssigned++;
                                results.Add($" Assigned {animal.Name} to enclosure: {enclosure.Name}");
                            }
                        }
                    }
                }

                // Create new enclosures for remaining animals
                while (groupAnimals.Any())
                {
                    // Take up to 5 animals per enclosure
                    var animalsForThisEnclosure = new List<Animal>();
                    double totalSpaceNeeded = 0;

                    foreach (var animal in groupAnimals.Take(5).ToList())
                    {
                        animalsForThisEnclosure.Add(animal);
                        totalSpaceNeeded += animal.SpaceRequirement;
                    }

                    // Add 20% buffer space
                    double enclosureSize = totalSpaceNeeded * 1.2;

                    var habitat = Enclosure.HabitatEnum.Grassland; 
                    var climate = Enclosure.ClimateEnum.Temperate; 

                    // Create new enclosure
                    var newEnclosure = new Enclosure
                    {
                        Name = $"{group.Key.Category} Enclosure {enclosuresCreated + 1}",
                        SecurityLevel = group.Key.SecurityRequirement,
                        Size = enclosureSize,
                        Habitat = habitat,
                        Climate = climate
                    };

                    _context.Enclosures.Add(newEnclosure);
                    await _context.SaveChangesAsync();
                    enclosuresCreated++;

                    results.Add($"  Created new enclosure: {newEnclosure.Name} (Size: {enclosureSize:F2}, Security: {newEnclosure.SecurityLevel})");

                    // Assign animals to the new enclosure
                    foreach (var animal in animalsForThisEnclosure)
                    {
                        animal.EnclosureId = newEnclosure.Id;
                        groupAnimals.Remove(animal);
                        animalsAssigned++;
                        results.Add($"  Assigned {animal.Name} to {newEnclosure.Name}");
                    }

                    await _context.SaveChangesAsync();
                }

                results.Add("");
            }

            results.Add("=== Auto Assignment Complete ===");
            results.Add($"Total enclosures created: {enclosuresCreated}");
            results.Add($"Total animals assigned: {animalsAssigned}");

            ViewData["ActionName"] = "Auto Assignment Complete";
            return View("ActionResult", results);
        }

        private bool ZooExists(int id)
        {
            return _context.Zoo.Any(e => e.Id == id);
        }
    }
}
