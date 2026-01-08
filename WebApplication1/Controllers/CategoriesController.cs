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
    public class CategoriesController : Controller
    {
        private readonly ZooDbContext _context;

        public CategoriesController(ZooDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index(string? searchTerm)
        {
            ViewData["SearchTerm"] = searchTerm;

            var categories = await _context.Categories
                .Include(c => c.Animals)
                .ToListAsync();

            var projected = categories.Select(c => new
            {
                c.Id,
                c.Name,
                AnimalCount = c.Animals.Count
            }).ToList();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim();
                projected = projected
                    .Where(c => c.Name.Contains(term, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(projected);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.Animals)
                    .ThenInclude(a => a.Enclosure)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.Animals)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Animals)
                .FirstOrDefaultAsync(c => c.Id == id);
            
            if (category != null)
            {
                // First unassign all animals from this category
                foreach (var animal in category.Animals)
                {
                    animal.CategoryId = null;
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/AssignAnimals/5
        public async Task<IActionResult> AssignAnimals(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.Animals)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            // Get all animals with their current category status
            var allAnimals = await _context.Animals
                .Include(a => a.Enclosure)
                .Include(a => a.Category)
                .ToListAsync();

            var projected = allAnimals.Select(a => new
            {
                a.Id,
                a.Name,
                a.Species,
                a.Enclosure,
                a.Category,
                IsAssigned = a.CategoryId == id
            }).ToList();

            ViewData["CategoryName"] = category.Name;
            ViewData["CategoryId"] = id;
            return View(projected);
        }

        // POST: Categories/AssignAnimals/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignAnimals(int id, List<int> selectedAnimalIds)
        {
            var category = await _context.Categories
                .Include(c => c.Animals)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
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
                    // Assign to this category
                    animal.CategoryId = id;
                }
                else if (animal.CategoryId == id)
                {
                    // Remove from this category if it was previously assigned
                    animal.CategoryId = null;
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = id });
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
