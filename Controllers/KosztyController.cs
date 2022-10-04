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
    public class KosztyController : Controller
    {
        private readonly DataContext _context;

        public KosztyController(DataContext context)
        {
            _context = context;
        }

        // GET: Koszty
        public async Task<IActionResult> Index()
        {
              return View(await _context.Koszty.ToListAsync());
        }

        // GET: Koszty/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Koszty == null)
            {
                return NotFound();
            }

            var koszt = await _context.Koszty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (koszt == null)
            {
                return NotFound();
            }

            return View(koszt);
        }

        // GET: Koszty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Koszty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataWystawieniaFaktury,NumerFaktury,NipFirmy,OpisKosztu,RodzajKosztu,WartoscNetto,WartoscVat,WartoscBrutto")] Koszt koszt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(koszt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(koszt);
        }

        // GET: Koszty/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Koszty == null)
            {
                return NotFound();
            }

            var koszt = await _context.Koszty.FindAsync(id);
            if (koszt == null)
            {
                return NotFound();
            }
            return View(koszt);
        }

        // POST: Koszty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,DataWystawieniaFaktury,NumerFaktury,NipFirmy,OpisKosztu,RodzajKosztu,WartoscNetto,WartoscVat,WartoscBrutto")] Koszt koszt)
        {
            if (id != koszt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(koszt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KosztExists(koszt.Id))
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
            return View(koszt);
        }

        // GET: Koszty/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Koszty == null)
            {
                return NotFound();
            }

            var koszt = await _context.Koszty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (koszt == null)
            {
                return NotFound();
            }

            return View(koszt);
        }

        // POST: Koszty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Koszty == null)
            {
                return Problem("Entity set 'DataContext.Koszty'  is null.");
            }
            var koszt = await _context.Koszty.FindAsync(id);
            if (koszt != null)
            {
                _context.Koszty.Remove(koszt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KosztExists(long id)
        {
          return _context.Koszty.Any(e => e.Id == id);
        }
    }
}
