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
    public class AnimalsController : Controller
    {
        private readonly ZooDbContext _context;

        public AnimalsController(ZooDbContext context)
        {
            _context = context;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
            var zooDbContext = _context.Animals.Include(a => a.Category).Include(a => a.Enclosure);
            return View(await zooDbContext.ToListAsync());
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .Include(a => a.Category)
                .Include(a => a.Enclosure)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            ViewData["CategoryList"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["EnclosureList"] = new SelectList(_context.Enclosures, "Id", "Name");
            return View();
        }

        // POST: Animals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    animal.Category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == animal.CategoryId);
                    animal.Enclosure = await _context.Enclosures.FirstOrDefaultAsync(e => e.Id == animal.EnclosureId);

                    _context.Add(animal);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating animal: {ex.Message}");
                }
            }

            ViewData["CategoryList"] = new SelectList(_context.Categories, "Id", "Name", animal.CategoryId);
            ViewData["EnclosureList"] = new SelectList(_context.Enclosures, "Id", "Name", animal.EnclosureId);
            return View(animal);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            ViewData["CategoryList"] = new SelectList(_context.Categories, "Id", "Name", animal.CategoryId);
            ViewData["EnclosureList"] = new SelectList(_context.Enclosures, "Id", "Name", animal.EnclosureId);
            return View(animal);
        }

        // POST: Animals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
            }

            ViewData["CategoryList"] = new SelectList(_context.Categories, "Id", "Name", animal.CategoryId);
            ViewData["EnclosureList"] = new SelectList(_context.Enclosures, "Id", "Name", animal.EnclosureId);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.Id == id);
        }

        // Actions: Sunrise for Individual Animal
        public async Task<IActionResult> Sunrise(int id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);

            if (animal == null)
                return NotFound("Animal not found.");

            string status;
            switch (animal.ActivityPattern)
            {
                case Animal.Activity.Diurnal:
                    status = $"{animal.Name} wakes up!";
                    animal.IsAwake = true;
                    break;
                case Animal.Activity.Nocturnal:
                    status = $"{animal.Name} goes to sleep.";
                    animal.IsAwake = false;
                    break;
                default:
                    status = $"{animal.Name} is active regardless";
                    animal.IsAwake = true;
                    break;
            }

            _context.Update(animal);
            await _context.SaveChangesAsync();

            ViewData["ActionName"] = "Sunrise";
            ViewData["AnimalName"] = animal.Name;
            return View("ActionResult", status);
        }

        // Actions: Sunset for Individual Animal
        public async Task<IActionResult> Sunset(int id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);

            if (animal == null)
                return NotFound("Animal not found.");

            string status;
            switch (animal.ActivityPattern)
            {
                case Animal.Activity.Nocturnal:
                    status = $"{animal.Name} wakes up!";
                    animal.IsAwake = true;
                    break;
                case Animal.Activity.Diurnal:
                    status = $"{animal.Name} goes to sleep.";
                    animal.IsAwake = false;
                    break;
                default:
                    status = $"{animal.Name} is active regardless";
                    animal.IsAwake = true;
                    break;
            }

            _context.Update(animal);
            await _context.SaveChangesAsync();

            ViewData["ActionName"] = "Sunset";
            ViewData["AnimalName"] = animal.Name;
            return View("ActionResult", status);
        }

        // Actions: Feeding Time for Individual Animal
        public async Task<IActionResult> FeedingTime(int id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);

            if (animal == null)
                return NotFound("Animal not found.");

            string status;

            // Check if the animal has a specific prey
            if (!string.IsNullOrEmpty(animal.Prey))
            {
                status = $"{animal.Name} eats its prey:  {animal.Prey}";
            }
            else
            {
                // Default output
                status = $"{animal.Name} is fed according to its diet: {animal.DietaryClass}.";
            }

            ViewData["ActionName"] = "Feeding Time";
            ViewData["AnimalName"] = animal.Name;
            return View("ActionResult", status);
        }

        // Actions: Check Constraints for Individual Animal
        public async Task<IActionResult> CheckConstraints(int id)
        {
            var animal = await _context.Animals.Include(a => a.Enclosure).FirstOrDefaultAsync(a => a.Id == id);

            if (animal == null)
                return NotFound("Animal not found.");

            List<string> messages = new();

            if (animal.Enclosure == null)
            {
                messages.Add($"{animal.Name} doesn't have an enclosure!");
            }
            else
            {
                double availableSpace = animal.Enclosure.Size / animal.Enclosure.Animals.Count;
                bool hasEnoughSpace = availableSpace >= animal.SpaceRequirement;
                bool meetsSecurityRequirements = (int)animal.SecurityRequirement <= (int)animal.Enclosure.SecurityLevel;

                // Space check
                if (hasEnoughSpace)
                {
                    messages.Add($"{animal.Name} has sufficient space in {animal.Enclosure.Name}.");
                }
                else
                {
                    messages.Add($"{animal.Name} has insufficient space in {animal.Enclosure.Name}.");
                }

                // Security check
                if (meetsSecurityRequirements)
                {
                    messages.Add($"{animal.Name} meets the security requirements in {animal.Enclosure.Name}.");
                }
                else
                {
                    messages.Add($"{animal.Name} does not meet the security requirements in {animal.Enclosure.Name}.");
                }

                // Mood determination
                if (hasEnoughSpace && meetsSecurityRequirements)
                {
                    messages.Add($"{animal.Name} is happy! The enclosure meets all constraints!");
                }
                else if (hasEnoughSpace || meetsSecurityRequirements)
                {
                    messages.Add($"{animal.Name} is in a sad mood! The enclosure {(hasEnoughSpace ? "lacks security" : "needs more space")}!");
                }
                else
                {
                    messages.Add($"{animal.Name} is very sad! The enclosure needs more space and security!");
                }
            }

            ViewData["ActionName"] = "Check Constraints";
            ViewData["AnimalName"] = animal.Name;
            return View("ActionResultList", messages);
        }
    }
}
