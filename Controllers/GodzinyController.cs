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
    public class GodzinyController : Controller
    {
        private readonly DataContext _context;

        public GodzinyController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Godziny
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Godziny>>> GetGodziny()
        {
            return await _context.Godziny.ToListAsync();
        }

        //GET: api/Godziny/NazwaProjektu
        [HttpGet("{NazwaProjektu}")]
        public async Task<ActionResult<IEnumerable<Godziny>>> GetGodzinyZProjektu(string NazwaProjektu)
        {
            return await _context.Godziny.Where(x => x.NazwaProjektu == NazwaProjektu).ToListAsync();
        }

        // POST: api/Godziny
        [HttpPost]
        public async Task<ActionResult<Godziny>> PostGodziny(Godziny godziny)
        {
            _context.Godziny.Add(godziny);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGodziny", new { id = godziny.Id }, godziny);
        }

        private bool GodzinyExists(long id)
        {
            return _context.Godziny.Any(e => e.Id == id);
        }

        // PUT: api/Godziny
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGodziny(int id, Godziny godziny)
        {
            if (id != godziny.Id)
            {
                return BadRequest();
            }

            _context.Entry(godziny).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GodzinyExists(id))
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

        // DELETE: api/Godziny/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGodziny(int id)
        {
            var godziny = await _context.Godziny.FindAsync(id);
            if (godziny == null)
            {
                return NotFound();
            }

            _context.Godziny.Remove(godziny);
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }

}
