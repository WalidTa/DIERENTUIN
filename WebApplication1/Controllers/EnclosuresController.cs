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
    public class EnclosuresController : Controller
    {
        private readonly ZooDbContext _context;

        public EnclosuresController(ZooDbContext context)
        {
            _context = context;
        }

        // GET: Enclosures
        public async Task<IActionResult> Index(string? searchTerm)
        {
            ViewData["SearchTerm"] = searchTerm;

            var enclosures = await _context.Enclosures
                .Include(e => e.Animals)
                .ToListAsync();

            var projected = enclosures.Select(e => new
            {
                e.Id,
                e.Name,
                e.SecurityLevel,
                e.Size,
                e.Habitat,
                e.Climate,
                AnimalCount = e.Animals.Count
            }).ToList();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim();
                projected = projected
                    .Where(e => 
                        e.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                        e.SecurityLevel.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) ||
                        e.Size.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) ||
                        e.Habitat.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) ||
                        e.Climate.ToString().Contains(term, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(projected);
        }

        // GET: Enclosures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure = await _context.Enclosures
                .Include(e => e.Animals)
                    .ThenInclude(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (enclosure == null)
            {
                return NotFound();
            }

            return View(enclosure);
        }

        // GET: Enclosures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enclosures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SecurityLevel,Size,Habitat,Climate")] Enclosure enclosure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enclosure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enclosure);
        }

        // GET: Enclosures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure = await _context.Enclosures.FindAsync(id);
            if (enclosure == null)
            {
                return NotFound();
            }
            return View(enclosure);
        }

        // POST: Enclosures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SecurityLevel,Size,Habitat,Climate")] Enclosure enclosure)
        {
            if (id != enclosure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enclosure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnclosureExists(enclosure.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(enclosure);
        }

        // GET: Enclosures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure = await _context.Enclosures
                .Include(e => e.Animals)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (enclosure == null)
            {
                return NotFound();
            }

            return View(enclosure);
        }

        // POST: Enclosures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enclosure = await _context.Enclosures
                .Include(e => e.Animals)
                .FirstOrDefaultAsync(e => e.Id == id);
            
            if (enclosure != null)
            {
                // First unassign all animals from this enclosure
                foreach (var animal in enclosure.Animals)
                {
                    animal.EnclosureId = null;
                }

                _context.Enclosures.Remove(enclosure);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Enclosures/AssignAnimals/5
        public async Task<IActionResult> AssignAnimals(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure = await _context.Enclosures
                .Include(e => e.Animals)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (enclosure == null)
            {
                return NotFound();
            }

            // Get all animals with their enclosure and category loaded
            var allAnimals = await _context.Animals
                .Include(a => a.Enclosure)
                .Include(a => a.Category)
                .ToListAsync();

            // Project to anonymous type after loading
            var projected = allAnimals.Select(a => new
            {
                a.Id,
                a.Name,
                a.Species,
                Category = a.Category,
                Enclosure = a.Enclosure,
                a.SpaceRequirement,
                a.SecurityRequirement,
                IsAssigned = a.EnclosureId == id
            }).ToList();

            ViewData["EnclosureName"] = enclosure.Name;
            ViewData["EnclosureId"] = id;
            return View(projected);
        }

        // POST: Enclosures/AssignAnimals/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignAnimals(int id, List<int> selectedAnimalIds)
        {
            var enclosure = await _context.Enclosures
                .Include(e => e.Animals)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (enclosure == null)
            {
                return NotFound();
            }

            // Get all animals
            var allAnimals = await _context.Animals.ToListAsync();

            // Update assignments
            foreach (var animal in allAnimals)
            {
                if (selectedAnimalIds != null && selectedAnimalIds.Contains(animal.Id))
                {
                    // Assign to this enclosure
                    animal.EnclosureId = id;
                }
                else if (animal.EnclosureId == id)
                {
                    // Remove from this enclosure if it was previously assigned
                    animal.EnclosureId = null;
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = id });
        }

        // Zoo Actions for enclosure - works on all animals in the enclosure
        
        public async Task<IActionResult> Sunrise(int id)
        {
            var enclosure = await _context.Enclosures
                .Include(e => e.Animals)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (enclosure == null)
                return NotFound("Enclosure not found.");

            if (!enclosure.Animals.Any())
            {
                ViewData["ActionName"] = "Sunrise";
                ViewData["EnclosureName"] = enclosure.Name;
                ViewData["OriginController"] = "Enclosures";
                return View("ActionResult", "No animals in this enclosure.");
            }

            var results = new List<string>();

            foreach (var animal in enclosure.Animals)
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
                results.Add(status);
                _context.Update(animal);
            }

            await _context.SaveChangesAsync();

            ViewData["ActionName"] = $"Sunrise in {enclosure.Name}";
            ViewData["EnclosureName"] = enclosure.Name;
            ViewData["OriginController"] = "Enclosures";
            return View("ActionResult", results);
        }

        // Actions: Sunset for Enclosure
        public async Task<IActionResult> Sunset(int id)
        {
            var enclosure = await _context.Enclosures
                .Include(e => e.Animals)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (enclosure == null)
                return NotFound("Enclosure not found.");

            if (!enclosure.Animals.Any())
            {
                ViewData["ActionName"] = "Sunset";
                ViewData["EnclosureName"] = enclosure.Name;
                ViewData["OriginController"] = "Enclosures";
                return View("ActionResult", "No animals in this enclosure.");
            }

            var results = new List<string>();

            foreach (var animal in enclosure.Animals)
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
                results.Add(status);
                _context.Update(animal);
            }

            await _context.SaveChangesAsync();

            ViewData["ActionName"] = $"Sunset in {enclosure.Name}";
            ViewData["EnclosureName"] = enclosure.Name;
            ViewData["OriginController"] = "Enclosures";
            return View("ActionResult", results);
        }

        // Actions: Feeding Time for Enclosure
        public async Task<IActionResult> FeedingTime(int id)
        {
            var enclosure = await _context.Enclosures
                .Include(e => e.Animals)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (enclosure == null)
                return NotFound("Enclosure not found.");

            if (!enclosure.Animals.Any())
            {
                ViewData["ActionName"] = "Feeding Time";
                ViewData["EnclosureName"] = enclosure.Name;
                ViewData["OriginController"] = "Enclosures";
                return View("ActionResult", "No animals in this enclosure.");
            }

            var results = new List<string>();

            foreach (var animal in enclosure.Animals)
            {
                string status;

                // Check if the animal has a specific prey
                if (!animal.IsAwake)
                {
                    status = $"{animal.Name} is asleep right now because the sun is {(animal.ActivityPattern == Animal.Activity.Nocturnal ? "up" : "down")}!";
                }
                else if (!string.IsNullOrEmpty(animal.Prey))
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

            ViewData["ActionName"] = $"Feeding Time in {enclosure.Name}";
            ViewData["EnclosureName"] = enclosure.Name;
            ViewData["OriginController"] = "Enclosures";
            return View("ActionResult", results);
        }

        // Actions: Check Constraints for Enclosure
        public async Task<IActionResult> CheckConstraints(int id)
        {
            var enclosure = await _context.Enclosures
                .Include(e => e.Animals)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (enclosure == null)
                return NotFound("Enclosure not found.");

            if (!enclosure.Animals.Any())
            {
                ViewData["ActionName"] = "Check Constraints";
                ViewData["EnclosureName"] = enclosure.Name;
                ViewData["OriginController"] = "Enclosures";
                return View("ActionResult", "No animals in this enclosure.");
            }

            var results = new List<string>();

            // Add enclosure summary
            results.Add($"=== {enclosure.Name} constraint check ===");
            results.Add($"Total Size: {enclosure.Size} | Security Level: {enclosure.SecurityLevel}");
            results.Add($"Number of Animals: {enclosure.Animals.Count}");
            results.Add("");

            foreach (var animal in enclosure.Animals)
            {
                results.Add($"--- {animal.Name} ({animal.Species}) ---");

                // Calculate space per animal in enclosure
                double availableSpace = enclosure.Size / enclosure.Animals.Count;
                bool hasEnoughSpace = availableSpace >= animal.SpaceRequirement;
                bool meetsSecurityRequirements = (int)animal.SecurityRequirement <= (int)enclosure.SecurityLevel;

                results.Add($"Space: Requires {animal.SpaceRequirement}, has {availableSpace:F2} - {(hasEnoughSpace ? " Sufficient" : " Insufficient")}");
                results.Add($"Security: Requires {animal.SecurityRequirement}, enclosure has {enclosure.SecurityLevel} - {(meetsSecurityRequirements ? " Met" : " Not met")}");

                // Determine mood based on constraints
                if (hasEnoughSpace && meetsSecurityRequirements)
                {
                    results.Add($"Status: {animal.Name} is happy! All constraints met!");
                }
                else if (hasEnoughSpace || meetsSecurityRequirements)
                {
                    results.Add($"Status: {animal.Name} is in a sad mood! {(hasEnoughSpace ? "Lacks security" : "Needs more space")}");
                }
                else
                {
                    results.Add($"Status: {animal.Name} is very sad! Needs more space and security!");
                }

                results.Add("");
            }

            var happyAnimals = enclosure.Animals.Count(a =>
            {
                double space = enclosure.Size / enclosure.Animals.Count;
                return space >= a.SpaceRequirement && (int)a.SecurityRequirement <= (int)enclosure.SecurityLevel;
            });

            results.Add($"=== Overall Health ===");
            results.Add($"{happyAnimals} out of {enclosure.Animals.Count} animals are happy");

            ViewData["ActionName"] = $"Check Constraints in {enclosure.Name}";
            ViewData["EnclosureName"] = enclosure.Name;
            ViewData["OriginController"] = "Enclosures";
            return View("ActionResult", results);
        }

        private bool EnclosureExists(int id)
        {
            return _context.Enclosures.Any(e => e.Id == id);
        }
    }
}
