﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ehpad.ORM;

namespace Ehpad.WEB.Controllers
{
    public class VaccinTypeController : Controller
    {
        private readonly Context _context;

        public VaccinTypeController(Context context)
        {
            _context = context;
        }

        // GET: VaccinType
        public async Task<IActionResult> Index()
        {
            return View(await _context.VaccineTypes.ToListAsync());
        }

        // GET: VaccinType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineType = await _context.VaccineTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineType == null)
            {
                return NotFound();
            }

            return View(vaccineType);
        }

        // GET: VaccinType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VaccinType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] VaccinType vaccineType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccineType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaccineType);
        }

        // GET: VaccinType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineType = await _context.VaccineTypes.FindAsync(id);
            if (vaccineType == null)
            {
                return NotFound();
            }
            return View(vaccineType);
        }

        // POST: VaccinType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] VaccinType vaccineType)
        {
            if (id != vaccineType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccineType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccinTypeExists(vaccineType.Id))
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
            return View(vaccineType);
        }

        // GET: VaccinType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineType = await _context.VaccineTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineType == null)
            {
                return NotFound();
            }

            return View(vaccineType);
        }

        // POST: VaccinType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccineType = await _context.VaccineTypes.FindAsync(id);
            _context.VaccineTypes.Remove(vaccineType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccinTypeExists(int id)
        {
            return _context.VaccineTypes.Any(e => e.Id == id);
        }
    }
}
