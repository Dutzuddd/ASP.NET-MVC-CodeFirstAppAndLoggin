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
    public class ProceseController : Controller
    {
        private readonly AppDataContext _context;

        public ProceseController(AppDataContext context)
        {
            _context = context;
        }

        // GET: Procese
        public async Task<IActionResult> Index()
        {
              return _context.Procese != null ? 
                          View(await _context.Procese.ToListAsync()) :
                          Problem("Entity set 'AppDataContext.Procese'  is null.");
        }

        // GET: Procese/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Procese == null)
            {
                return NotFound();
            }

            var procese = await _context.Procese
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procese == null)
            {
                return NotFound();
            }

            return View(procese);
        }

        // GET: Procese/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procese/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Locatie,Data_Ora,Rezultat,Id_dosar")] Procese procese)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procese);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procese);
        }

        // GET: Procese/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Procese == null)
            {
                return NotFound();
            }

            var procese = await _context.Procese.FindAsync(id);
            if (procese == null)
            {
                return NotFound();
            }
            return View(procese);
        }

        // POST: Procese/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Locatie,Data_Ora,Rezultat,Id_dosar")] Procese procese)
        {
            if (id != procese.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procese);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProceseExists(procese.Id))
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
            return View(procese);
        }

        // GET: Procese/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Procese == null)
            {
                return NotFound();
            }

            var procese = await _context.Procese
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procese == null)
            {
                return NotFound();
            }

            return View(procese);
        }

        // POST: Procese/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Procese == null)
            {
                return Problem("Entity set 'AppDataContext.Procese'  is null.");
            }
            var procese = await _context.Procese.FindAsync(id);
            if (procese != null)
            {
                _context.Procese.Remove(procese);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProceseExists(int id)
        {
          return (_context.Procese?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
