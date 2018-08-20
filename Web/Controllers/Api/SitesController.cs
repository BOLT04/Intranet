using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.DAL;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SitesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Sites
        [HttpGet]
        public async Task<IEnumerable<object>> GetSites()
        {            
            return await _context.Sites.ToListAsync();
        }

        // GET: api/Sites/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSite([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var site = await _context.Sites.FindAsync(id);

            if (site == null) return NotFound();
            
            return Ok(site);
        }

        // PUT: api/Sites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSite([FromRoute] int id, [FromBody] Site site)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != site.Id) return BadRequest();

            _context.Entry(site).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/Sites
        [HttpPost]
        public async Task<IActionResult> PostSite([FromBody] Site site)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Sites.Add(site);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSite", new {id = site.Id}, site);
        }

        // DELETE: api/Sites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSite([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var site = await _context.Sites.FindAsync(id);
            if (site == null) return NotFound();

            _context.Sites.Remove(site);
            await _context.SaveChangesAsync();

            return Ok(site);
        }

        private bool SiteExists(int id)
        {
            return _context.Sites.Any(e => e.Id == id);
        }
    }
}