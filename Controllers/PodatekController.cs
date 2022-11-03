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
    [Route("api/[controller]")]
    [ApiController]
    public class PodatekController : Controller
    {
        private readonly DataContext _context;

        public PodatekController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Podatek
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Podatek>>> GetPodatki()
        {
            return await _context.Podatek.ToListAsync();
        }

        //GET: api/Podatek/Rok/Miesiac
        [HttpGet("{Rok}/{Miesiac}")]
        public async Task<ActionResult<IEnumerable<Podatek>>> GetPodatkiZRokuZMiesiaca(int Rok, int Miesiac)
        {
            return await _context.Podatek
                .Where(x => x.Rok == Rok)
                .Where(x => x.Miesiac == Miesiac)
                .ToListAsync();
        }

        // POST: api/Podatek
        [HttpPost]
        public async Task<ActionResult<Podatek>> PostPodatek(Podatek podatek)
        {
            _context.Podatek.Add(podatek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPodatki", new { id = podatek.Id }, podatek);
        }
        private bool PodatekExists(long id)
        {
            return _context.Podatek.Any(e => e.Id == id);
        }

        // PUT: api/ZestawienieGodzin
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPodatek(int id, Podatek podatek)
        {
            if (id != podatek.Id)
            {
                return BadRequest();
            }

            _context.Entry(podatek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PodatekExists(id))
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

        // DELETE: api/Podatek/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePodatek(int id)
        {
            var Podatek = await _context.Podatek.FindAsync(id);
            if (Podatek == null)
            {
                return NotFound();
            }

            _context.Podatek.Remove(Podatek);
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }
}
