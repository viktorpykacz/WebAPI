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
    public class ZestawienieGodzinController : Controller
    {
        private readonly DataContext _context;

        public ZestawienieGodzinController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ZestawienieGodzin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZestawienieGodzin>>> GetZestawienieGodzin()
        {
            return await _context.ZestawienieGodzin.ToListAsync();
        }

        //GET: api/ZestawienieGodzin/NazwaProjektu
        [HttpGet("{NazwaProjektu}")]
        public async Task<ActionResult<IEnumerable<ZestawienieGodzin>>> GetZestawienieGodzinZProjektu(string NazwaProjektu)
        {
            return await _context.ZestawienieGodzin.Where(x => x.NazwaProjektu == NazwaProjektu).ToListAsync();
        }

        //GET: api/ZestawienieGodzin/Rok/Miesiac
        [HttpGet("{NazwaProjektu}/{Rok}/{Miesiac}")]
        public async Task<ActionResult<IEnumerable<ZestawienieGodzin>>> GetZestawienieGodzinZProjektuZRokuZMiesiaca(string NazwaProjektu, int Rok, int Miesiac)
        {
            return await _context.ZestawienieGodzin
                .Where(x => x.NazwaProjektu == NazwaProjektu)
                .Where(x => x.Rok == Rok)
                .Where(x => x.Miesiac == Miesiac)
                .ToListAsync();
        }

        // POST: api/ZestawienieGodzin
        [HttpPost]
        public async Task<ActionResult<ZestawienieGodzin>> PostZestawienieGodzin(ZestawienieGodzin zestawienieGodzin)
        {
            _context.ZestawienieGodzin.Add(zestawienieGodzin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZestawienieGodzin", new { id = zestawienieGodzin.Id }, zestawienieGodzin);
        }

        private bool ZestawienieGodzinExists(long id)
        {
            return _context.ZestawienieGodzin.Any(e => e.Id == id);
        }

        // PUT: api/ZestawienieGodzin
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGodziny(int id, ZestawienieGodzin zestawienieGodzin)
        {
            if (id != zestawienieGodzin.Id)
            {
                return BadRequest();
            }

            _context.Entry(zestawienieGodzin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZestawienieGodzinExists(id))
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

        // DELETE: api/ZestawienieGodzin/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZestawienieGodzin(int id)
        {
            var ZestawienieGodzin = await _context.ZestawienieGodzin.FindAsync(id);
            if (ZestawienieGodzin == null)
            {
                return NotFound();
            }

            _context.ZestawienieGodzin.Remove(ZestawienieGodzin);
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }

}
