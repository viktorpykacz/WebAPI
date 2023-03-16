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
    public class PrzychodyController : ControllerBase
    {
        private readonly DataContext _context;

        public PrzychodyController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Przychody
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Przychod>>> GetPrzychody()
        {
            return await _context.Przychody.OrderByDescending(x => x.DataWystawieniaFaktury).ToListAsync();
        }


        // POST: api/Przychody
        [HttpPost]
        public async Task<ActionResult<Przychod>> PostPrzychody(Przychod przychody)
        {
            _context.Przychody.Add(przychody);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrzychody", new { id = przychody.Id }, przychody);
        }

        private bool PrzychodyExists(int id)
        {
            return _context.Przychody.Any(e => e.Id == id);
        }

        // PUT: api/Przychody/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrzychody(int id, Przychod przychody)
        {
            if (id != przychody.Id)
            {
                return BadRequest();
            }

            _context.Entry(przychody).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrzychodyExists(id))
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

        // DELETE: api/Przychody/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrzychody(int id)
        {
            var przychody = await _context.Przychody.FindAsync(id);
            if (przychody == null)
            {
                return NotFound();
            }

            _context.Przychody.Remove(przychody);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
