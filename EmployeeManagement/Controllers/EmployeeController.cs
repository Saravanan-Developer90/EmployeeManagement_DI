using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models.EF;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeManagementContext _context;

        public EmployeeController(EmployeeManagementContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeInfo>>> GetEmployeeInfos()
        {
          if (_context.EmployeeInfos == null)
          {
              return NotFound();
          }
            return await _context.EmployeeInfos.ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeInfo>> GetEmployeeInfo(int id)
        {
          if (_context.EmployeeInfos == null)
          {
              return NotFound();
          }
            var employeeInfo = await _context.EmployeeInfos.FindAsync(id);

            if (employeeInfo == null)
            {
                return NotFound();
            }

            return employeeInfo;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeInfo(int id, EmployeeInfo employeeInfo)
        {
            if (id != employeeInfo.EmpNo)
            {
                return BadRequest();
            }

            _context.Entry(employeeInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeInfoExists(id))
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

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeInfo>> PostEmployeeInfo(EmployeeInfo employeeInfo)
        {
          if (_context.EmployeeInfos == null)
          {
              return Problem("Entity set 'EmployeeManagementContext.EmployeeInfos'  is null.");
          }
            _context.EmployeeInfos.Add(employeeInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeInfoExists(employeeInfo.EmpNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeInfo", new { id = employeeInfo.EmpNo }, employeeInfo);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeInfo(int id)
        {
            if (_context.EmployeeInfos == null)
            {
                return NotFound();
            }
            var employeeInfo = await _context.EmployeeInfos.FindAsync(id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            _context.EmployeeInfos.Remove(employeeInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeInfoExists(int id)
        {
            return (_context.EmployeeInfos?.Any(e => e.EmpNo == id)).GetValueOrDefault();
        }
    }
}
