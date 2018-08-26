using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.DAL;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels;
using Web.ViewModels.EmployeeViewModels;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EmployeesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            return _context.Employees.Select(e => new EmployeeViewModel
            {
                Id = e.Id,
                FirstName = e.FirstName,
                Surname = e.Surname,
                Sites = e.Sites.Select(s => new EmployeeSiteViewModel
                {
                    Id = s.SiteId,
                    Name = s.Site.Name,
                    Colour = s.Site.Colour
                }).ToList(),
                Signins = e.Signins.Select(s => new EmployeeSigninViewModel
                {
                    Id = s.Id,
                    SiteId = s.SiteId
                }).ToList()
            });
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null) return NotFound();

            var viewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                Surname = employee.Surname,
                Sites = employee.Sites.Select(s => new EmployeeSiteViewModel
                {
                    Id = s.SiteId,
                    Name = s.Site.Name,
                    Colour = s.Site.Colour
                }).ToList(),
                Signins = employee.Signins.Select(s => new EmployeeSigninViewModel
                {
                    Id = s.Id,
                    SiteId = s.SiteId
                }).ToList()
            };

            return Ok(viewModel);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != employee.Id) return BadRequest();

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new {id = employee.Id}, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}