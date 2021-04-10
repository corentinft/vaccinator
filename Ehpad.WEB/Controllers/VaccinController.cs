using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ehpad.ORM;

namespace Ehpad.WEB.Controllers
{
    public class VaccinController : Controller
    {
        private readonly Context _context;

        public VaccinController(Context context)
        {
            _context = context;
        }

        // GET: Vaccin
        public async Task<IActionResult> Index()
        {
            var context = _context.Vaccines.Include(v => v.VaccineType);
            return View(await context.ToListAsync());
        }

        // GET: Vaccin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccines
                .Include(v => v.VaccineType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccine == null)
            {
                return NotFound();
            }

            return View(vaccine);
        }

        // GET: Vaccin/Create
        public IActionResult Create()
        {
            ViewData["VaccineTypeId"] = new SelectList(_context.VaccineTypes, "Id", "Label");
            return View();
        }

        // POST: Vaccin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,VaccineTypeId")] Vaccin vaccine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VaccineTypeId"] = new SelectList(_context.VaccineTypes, "Id", "Label", vaccine.VaccineTypeId);
            return View(vaccine);
        }

        // GET: Vaccin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccines.FindAsync(id);
            if (vaccine == null)
            {
                return NotFound();
            }
            ViewData["VaccineTypeId"] = new SelectList(_context.VaccineTypes, "Id", "Label", vaccine.VaccineTypeId);
            return View(vaccine);
        }

        // POST: Vaccin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,VaccineTypeId")] Vaccin vaccine)
        {
            if (id != vaccine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccinExists(vaccine.Id))
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
            ViewData["VaccineTypeId"] = new SelectList(_context.VaccineTypes, "Id", "Label", vaccine.VaccineTypeId);
            return View(vaccine);
        }

        // GET: Vaccin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccines
                .Include(v => v.VaccineType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccine == null)
            {
                return NotFound();
            }

            return View(vaccine);
        }

        // POST: Vaccin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccine = await _context.Vaccines.FindAsync(id);
            _context.Vaccines.Remove(vaccine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccinExists(int id)
        {
            return _context.Vaccines.Any(e => e.Id == id);
        }
    }
}
