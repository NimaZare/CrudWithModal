using CrudWithModal.Data;
using CrudWithModal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWithModal.Controllers
{
    public class PeopleController(MyDbContext _context) : Controller
    {
        
        // GET: People
        public async Task<IActionResult> Index()
        {
            return View(await _context.Person.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null) return NotFound();

            var person = await _context.Person.FirstOrDefaultAsync(m => m.ID == id);

            if (person == null) return NotFound();

            return PartialView(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null) return NotFound();

            var person = await _context.Person.FindAsync(id);

            if (person == null) return NotFound();

            return PartialView(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,FirstName,LastName")] Person person)
        {
            if (id != person.ID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.ID))
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

            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null) return NotFound();

            var person = await _context.Person.FirstOrDefaultAsync(m => m.ID == id);

            if (person == null) return NotFound();

            return PartialView(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var person = await _context.Person.FindAsync(id);

            if (person != null)
                _context.Person.Remove(person);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(long id)
        {
            return _context.Person.Any(e => e.ID == id);
        }
    }
}
