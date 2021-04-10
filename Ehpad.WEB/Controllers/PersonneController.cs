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
    public class PersonneController : Controller
    {
        private readonly Context _context;

        public PersonneController(Context context)
        {
            _context = context;
        }

        // GET: Personne
        public async Task<IActionResult> Index()
        {
            var context = _context.Persons.Include(p => p.PersonType).Include(v => v.Vaccinates);
            return View(await context.ToListAsync());
        }

        // GET: Personne/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.PersonType)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Personne/Create
        public IActionResult Create()
        {
            ViewData["PersonTypeId"] = new SelectList(_context.PersonTypes, "Id", "Label");
            return View();
        }

        // POST: Personne/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Lastname,Gender,BirthDate,PersonTypeId")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonTypeId"] = new SelectList(_context.PersonTypes, "Id", "Label", person.PersonTypeId);
            return View(person);
        }

        // GET: Personne/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["PersonTypeId"] = new SelectList(_context.PersonTypes, "Id", "Label", person.PersonTypeId);
            return View(person);
        }

        // POST: Personne/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Lastname,Gender,BirthDate,PersonTypeId")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonneExists(person.Id))
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
            ViewData["PersonTypeId"] = new SelectList(_context.PersonTypes, "Id", "Label", person.PersonTypeId);
            return View(person);
        }

        // GET: Personne/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.PersonType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Personne/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Grippe()
        {
            var dateTime = DateTime.Today;
            var persons = await _context.Persons.Include(person => person.PersonType)
                .Include(person => person.Vaccinates)
                .ThenInclude(vaccinate => vaccinate.Vaccine)
                .ThenInclude(vaccine => vaccine.VaccineType).ToListAsync();
            var personsToDisplay = (from person in persons
                                    where !person.Vaccinates.Any(Vaccinate => Vaccinate.Vaccine.VaccineType.Label == "Grippe")
                                    || (person.Vaccinates.Any(Vaccinate => Vaccinate.Vaccine.VaccineType.Label == "Grippe"
                                        && Vaccinate.RecallDate.Year < dateTime.Year))
                                    select person).ToList();
            return View(personsToDisplay);
        }

        private bool PersonneExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }

        // GET : NotVaccinated
        public async Task<IActionResult> NotVaccinated()
        {
            var context = _context.Persons
                .Include(person => person.PersonType)
                .Include(vaccinates => vaccinates.Vaccinates)
                .ThenInclude(vaccine => vaccine.Vaccine)
                .ThenInclude(type => type.VaccineType);
            return View(await context.ToListAsync());
        }

        // GET : DelayRecall
        public async Task<IActionResult> DelayRecall()
        {
            var context = _context.Persons
                .Include(person => person.PersonType)
                .Include(vaccinates => vaccinates.Vaccinates)
                .ThenInclude(vaccine => vaccine.Vaccine)
                .ThenInclude(type => type.VaccineType);
            return View(await context.ToListAsync());
        }
    }
}

    
