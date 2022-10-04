using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    public class PrzychodyController : Controller
    {
        private readonly DataContext _context;

        public PrzychodyController(DataContext context)
        {
            _context = context;
        }

        // GET: Przychody
        public async Task<IActionResult> Index()
        {
              return View(await _context.Przychody.ToListAsync());
        }

        // GET: Przychody/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Przychody == null)
            {
                return NotFound();
            }

            var przychod = await _context.Przychody
                .FirstOrDefaultAsync(m => m.Id == id);
            if (przychod == null)
            {
                return NotFound();
            }

            return View(przychod);
        }

        // GET: Przychody/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Przychody/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataWystawieniaFaktury,NumerFaktury,NipFirmy,OpisFaktury,WartoscNetto,WartoscVat,WartoscBrutto")] Przychod przychod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(przychod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(przychod);
        }

        // GET: Przychody/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Przychody == null)
            {
                return NotFound();
            }

            var przychod = await _context.Przychody.FindAsync(id);
            if (przychod == null)
            {
                return NotFound();
            }
            return View(przychod);
        }

        // POST: Przychody/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,DataWystawieniaFaktury,NumerFaktury,NipFirmy,OpisFaktury,WartoscNetto,WartoscVat,WartoscBrutto")] Przychod przychod)
        {
            if (id != przychod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(przychod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrzychodExists(przychod.Id))
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
            return View(przychod);
        }

        // GET: Przychody/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Przychody == null)
            {
                return NotFound();
            }

            var przychod = await _context.Przychody
                .FirstOrDefaultAsync(m => m.Id == id);
            if (przychod == null)
            {
                return NotFound();
            }

            return View(przychod);
        }

        // POST: Przychody/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Przychody == null)
            {
                return Problem("Entity set 'DataContext.Przychody'  is null.");
            }
            var przychod = await _context.Przychody.FindAsync(id);
            if (przychod != null)
            {
                _context.Przychody.Remove(przychod);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrzychodExists(long id)
        {
          return _context.Przychody.Any(e => e.Id == id);
        }
    }
}
