using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.DAL;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.EmployeeViewModels;
using Web.ViewModels.ScreenViewModels;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SigninsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SigninsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Signins
        [HttpGet]
        public IEnumerable<SigninViewModel> GetSignins([FromQuery] int? EmployeeId)
        {
            return _context.Signins
                .Where(s => EmployeeId == null || s.EmployeeId == EmployeeId)
                .Select(s => new SigninViewModel
                {
                    Id = s.Id,
                    TimeIn = s.TimeIn,
                    TimeOut = s.TimeOut,
                    EmployeeId = s.EmployeeId,
                    SiteId = s.SiteId
                })
                .OrderByDescending(s => s.TimeIn);
        }

        // GET: api/Signins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSignin([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var signin = await _context.Signins.FindAsync(id);

            if (signin == null) return NotFound();

            var viewModel = new SigninViewModel
            {
                Id = signin.Id,
                TimeIn = signin.TimeIn,
                TimeOut = signin.TimeOut,
                EmployeeId = signin.EmployeeId,
                SiteId = signin.SiteId
            };

            return Ok(viewModel);
        }

        // PUT: api/Signins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSignin([FromRoute] int id, [FromBody] EditSigninViewModel editedSignin)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != editedSignin.SigninId) return BadRequest();

            if (!SigninExists(id))
                return NotFound();

            if (editedSignin.TimeOut.Kind != 0)
            {
                editedSignin.TimeOut = TimeZoneInfo.ConvertTimeFromUtc(editedSignin.TimeOut, TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
            }

            var signin = await _context.Signins.FindAsync(id);
            signin = EditSignin(signin, editedSignin);

            _context.Entry(signin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SigninExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/Signins
        [HttpPost]
        public async Task<IActionResult> PostSignin([FromBody] NewSigninViewModel newSignin)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var signin = new Signin() {
                EmployeeId = newSignin.EmployeeId,
                SiteId = newSignin.SiteId
            };

            _context.Signins.Add(signin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSignin", new {id = signin.Id}, signin);
        }

        // DELETE: api/Signin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSignin([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var signin = await _context.Signins.FindAsync(id);
            if (signin == null) return NotFound();

            _context.Signins.Remove(signin);
            await _context.SaveChangesAsync();

            return Ok(signin);
        }

        private bool SigninExists(int id)
        {
            return _context.Signins.Any(e => e.Id == id);
        }

        private Signin EditSignin(Signin signin, EditSigninViewModel edited)
        {
            signin.TimeIn = edited.TimeIn;
            signin.TimeOut = edited.TimeOut;
            return signin;
        }
    }
}