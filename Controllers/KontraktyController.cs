using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontraktyController : Controller
    {
        private readonly DataContext _context;

        public KontraktyController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Kontrakty
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kontrakt>>> GetKontrakty()
        {
            return await _context.Kontrakt.ToListAsync();
        }

        // POST: api/Kontrakty
        [HttpPost]
        public async Task<ActionResult<Kontrakt>> PostKontrakt(Kontrakt kontrakt)
        {
            _context.Kontrakt.Add(kontrakt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKontrakty", new { id = kontrakt.Id }, kontrakt);
        }
        private bool KontraktyExists(long id)
        {
            return _context.Kontrakt.Any(e => e.Id == id);
        }

        // PUT: api/Kontrakt
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKontrakt(int id, Kontrakt kontrakt)
        {
            if (id != kontrakt.Id)
            {
                return BadRequest();
            }

            _context.Entry(kontrakt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KontraktyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Kontrakty/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKontrakt(int id)
        {
            var kontrakt = await _context.Kontrakt.FindAsync(id);
            if (kontrakt == null)
            {
                return NotFound();
            }

            _context.Kontrakt.Remove(kontrakt);
            await _context.SaveChangesAsync();

            return NoContent();
        }






    }
}
