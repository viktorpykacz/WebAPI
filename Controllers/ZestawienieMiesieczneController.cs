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
    public class ZestawienieMiesieczneController : Controller
    {
        private readonly DataContext _context;

        public ZestawienieMiesieczneController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ZestawienieMiesieczne
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZestawienieMiesieczne>>> GetZestawienieMiesieczne()
        {
            return await _context.ZestawienieMiesieczne.ToListAsync();
        }


        //GET: api/ZestawienieMiesieczne/Rok/Miesiac
        [HttpGet("{Rok}/{Miesiac}")]
        public async Task<ActionResult<IEnumerable<ZestawienieMiesieczne>>> GetZestawienieMiesieczneZRokuZMiesiaca(int Rok, int Miesiac)
        {
            return await _context.ZestawienieMiesieczne
                .Where(x => x.Rok == Rok)
                .Where(x => x.Miesiac == Miesiac)
                .ToListAsync();
        }

        // POST: api/ZestawienieMiesieczne
        [HttpPost]
        public async Task<ActionResult<ZestawienieMiesieczne>> PostZestawienieMiesieczne(ZestawienieMiesieczne zestawienieMiesieczne)
        {
            _context.ZestawienieMiesieczne.Add(zestawienieMiesieczne);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZestawienieGodzin", new { id = zestawienieMiesieczne.Id }, zestawienieMiesieczne);
        }

        private bool ZestawienieMiesieczneExists(long id)
        {
            return _context.ZestawienieMiesieczne.Any(e => e.Id == id);
        }

        // PUT: api/ZestawienieMiesieczne
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZestawienieMiesieczne(int id, ZestawienieMiesieczne zestawienieMiesieczne)
        {
            if (id != zestawienieMiesieczne.Id)
            {
                return BadRequest();
            }

            _context.Entry(zestawienieMiesieczne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZestawienieMiesieczneExists(id))
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

        // DELETE: api/ZestawienieMiesieczne/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZestawienieMiesieczne(int id)
        {
            var ZestawienieMiesieczne = await _context.ZestawienieMiesieczne.FindAsync(id);
            if (ZestawienieMiesieczne == null)
            {
                return NotFound();
            }

            _context.ZestawienieMiesieczne.Remove(ZestawienieMiesieczne);
            await _context.SaveChangesAsync();

            return NoContent();
        }



    }
}
