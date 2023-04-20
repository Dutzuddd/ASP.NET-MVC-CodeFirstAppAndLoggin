using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_1_Sfranciog;
using Proiect_1_Sfranciog.Models;

namespace Proiect_1_Sfranciog.Controllers
{
    public class DosareController : Controller
    {
        private readonly AppDataContext _context;

        public DosareController(AppDataContext context)
        {
            _context = context;
        }

        // GET: Dosare
        public async Task<IActionResult> Index()
        {
              return _context.Dosare != null ? 
                          View(await _context.Dosare.ToListAsync()) :
                          Problem("Entity set 'AppDataContext.Dosare'  is null.");
        }

        // GET: Dosare/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dosare == null)
            {
                return NotFound();
            }

            var dosare = await _context.Dosare
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dosare == null)
            {
                return NotFound();
            }

            return View(dosare);
        }

        // GET: Dosare/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dosare/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Tip,Informatii,Concluzii,Onorariu,Id_Client")] Dosare dosare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dosare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dosare);
        }

        // GET: Dosare/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dosare == null)
            {
                return NotFound();
            }

            var dosare = await _context.Dosare.FindAsync(id);
            if (dosare == null)
            {
                return NotFound();
            }
            return View(dosare);
        }

        // POST: Dosare/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Tip,Informatii,Concluzii,Onorariu,Id_Client")] Dosare dosare)
        {
            if (id != dosare.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dosare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DosareExists(dosare.Id))
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
            return View(dosare);
        }

        // GET: Dosare/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dosare == null)
            {
                return NotFound();
            }

            var dosare = await _context.Dosare
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dosare == null)
            {
                return NotFound();
            }

            return View(dosare);
        }

        // POST: Dosare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dosare == null)
            {
                return Problem("Entity set 'AppDataContext.Dosare'  is null.");
            }
            var dosare = await _context.Dosare.FindAsync(id);
            if (dosare != null)
            {
                _context.Dosare.Remove(dosare);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DosareExists(int id)
        {
          return (_context.Dosare?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
