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


        //// GET: Zoos/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Zoos/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] Zoo zoo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(zoo);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(zoo);
        //}

        //// GET: Zoos/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var zoo = await _context.Zoo.FindAsync(id);
        //    if (zoo == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(zoo);
        //}

        //// POST: Zoos/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Zoo zoo)
        //{
        //    if (id != zoo.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(zoo);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ZooExists(zoo.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(zoo);
        //}

        //// GET: Zoos/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var zoo = await _context.Zoo
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (zoo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(zoo);
        //}

        //// POST: Zoos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var zoo = await _context.Zoo.FindAsync(id);
        //    if (zoo != null)
        //    {
        //        _context.Zoo.Remove(zoo);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ZooExists(int id)
        {
            return _context.Zoo.Any(e => e.Id == id);
        }
    }
}
