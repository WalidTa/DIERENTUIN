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

        private bool EnclosureExists(int id)
        {
            return _context.Enclosures.Any(e => e.Id == id);
        }
    }
}
