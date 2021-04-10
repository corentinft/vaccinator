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
    public class VaccinerController : Controller
    {
        private readonly Context _context;

        public VaccinerController(Context context)
        {
            _context = context;
        }

        // GET: Vacciner
        public async Task<IActionResult> Index()
        {
            var context = _context.Vaccinates.Include(v => v.Person).Include(v => v.Vaccine);
            return View(await context.ToListAsync());
        }

        // GET: Vacciner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinate = await _context.Vaccinates
                .Include(v => v.Person)
                .Include(v => v.Vaccine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccinate == null)
            {
                return NotFound();
            }

            return View(vaccinate);
        }

        // GET: Vacciner/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Firstname");
            ViewData["VaccineId"] = new SelectList(_context.Vaccines, "Id", "Brand");
            return View();
        }

        // POST: Vacciner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,RecallDate,BatchNumber,PersonId,VaccineId")] Vacciner vaccinate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccinate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Firstname", vaccinate.PersonId);
            ViewData["VaccineId"] = new SelectList(_context.Vaccines, "Id", "Brand", vaccinate.VaccineId);
            return View(vaccinate);
        }

        // GET: Vacciner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinate = await _context.Vaccinates.FindAsync(id);
            if (vaccinate == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Firstname", vaccinate.PersonId);
            ViewData["VaccineId"] = new SelectList(_context.Vaccines, "Id", "Brand", vaccinate.VaccineId);
            return View(vaccinate);
        }

        // POST: Vacciner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,RecallDate,BatchNumber,PersonId,VaccineId")] Vacciner vaccinate)
        {
            if (id != vaccinate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccinate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccinerExists(vaccinate.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "Firstname", vaccinate.PersonId);
            ViewData["VaccineId"] = new SelectList(_context.Vaccines, "Id", "Brand", vaccinate.VaccineId);
            return View(vaccinate);
        }

        // GET: Vacciner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinate = await _context.Vaccinates
                .Include(v => v.Person)
                .Include(v => v.Vaccine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccinate == null)
            {
                return NotFound();
            }

            return View(vaccinate);
        }

        // POST: Vacciner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccinate = await _context.Vaccinates.FindAsync(id);
            _context.Vaccinates.Remove(vaccinate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Vacciner/Person/5
        public async Task<IActionResult> Person(int id)
        {
            var context = _context.Vaccinates
                .Where(v => v.PersonId == id)
                .Include(v => v.Person)
                .Include(v => v.Vaccine);
            return View(await context.ToListAsync());
        }

        private bool VaccinerExists(int id)
        {
            return _context.Vaccinates.Any(e => e.Id == id);
        }
    }
}
