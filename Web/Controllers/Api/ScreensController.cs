using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.DAL;
using Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.ScreenViewModels;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreensController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ScreensController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Screens
        [HttpGet]
        public IEnumerable<Screen> GetScreens()
        {
            return _context.Screens;
        }

        // GET: api/Screens/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScreen([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var screen = await _context.Screens.FindAsync(id);

            if (screen == null) return NotFound();

            return Ok(screen);
        }

        // PUT: api/Screens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScreen([FromRoute] int id, [FromBody] Screen screen)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != screen.Id) return BadRequest();

            _context.Entry(screen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScreenExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/Screens
        [HttpPost]
        public async Task<IActionResult> PostScreen([FromBody] NewScreenModel screen)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToLower();
            string authCode = new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[new Random().Next(s.Length)]).ToArray());

            var newScreen = new Screen()
            {
                Name = screen.Name,
                AuthCode = authCode,
                SiteId = screen.SiteId
            };

            _context.Screens.Add(newScreen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScreen", new {id = newScreen.Id}, screen);
        }

        // DELETE: api/Screens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreen([FromRoute] string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var screen = await _context.Screens.FindAsync(id);
            if (screen == null) return NotFound();

            _context.Screens.Remove(screen);
            await _context.SaveChangesAsync();

            return Ok(screen);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterScreen([FromBody] ScreenCodeModel screenCodeModel)
        {
            var screen = await _context.Screens.Where(s => s.AuthCode == screenCodeModel.code).FirstOrDefaultAsync();

            if (screen == null) return NotFound();

            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.MaxValue
            };

            Response.Cookies.Append("Screen", screen.Id.ToString(), options);

            return Ok("Registered");
        }

        private bool ScreenExists(int id)
        {
            return _context.Screens.Any(e => e.Id == id);
        }
    }
}