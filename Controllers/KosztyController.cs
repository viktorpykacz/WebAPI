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

    public class KosztyController : ControllerBase
    {
        private readonly DataContext _context;

        public KosztyController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Koszty
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Koszt>>> GetKoszty()
        {
            return await _context.Koszty.OrderByDescending(x => x.DataWystawieniaFaktury).ToListAsync();
        }       

        
    }
}
