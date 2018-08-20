using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.DAL;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClockinsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ClockinsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Clockins
        [HttpGet]
        public IEnumerable<Clockin> GetClockins()
        {
            return _context.Clockins;
        }

        // GET: api/Clockins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClockin([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var clockin = await _context.Clockins.FindAsync(id);

            if (clockin == null) return NotFound();

            return Ok(clockin);
        }

        // PUT: api/Clockins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClockin([FromRoute] int id, [FromBody] Clockin clockin)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != clockin.Id) return BadRequest();

            _context.Entry(clockin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClockinExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/Clockins
        [HttpPost]
        public async Task<IActionResult> PostClockin([FromBody] Clockin clockin)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Clockins.Add(clockin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClockin", new {id = clockin.Id}, clockin);
        }

        // DELETE: api/Clockins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClockin([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var clockin = await _context.Clockins.FindAsync(id);
            if (clockin == null) return NotFound();

            _context.Clockins.Remove(clockin);
            await _context.SaveChangesAsync();

            return Ok(clockin);
        }

        private bool ClockinExists(int id)
        {
            return _context.Clockins.Any(e => e.Id == id);
        }
    }
}