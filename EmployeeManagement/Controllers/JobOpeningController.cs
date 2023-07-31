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
    public class JobOpeningController : ControllerBase
    {
        private readonly EmployeeManagementContext _context;

        public JobOpeningController(EmployeeManagementContext context)
        {
            _context = context;
        }

        // GET: api/JobOpening
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobOpening>>> GetJobOpenings()
        {
          if (_context.JobOpenings == null)
          {
              return NotFound();
          }
            return await _context.JobOpenings.ToListAsync();
        }

        // GET: api/JobOpening/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobOpening>> GetJobOpening(int id)
        {
          if (_context.JobOpenings == null)
          {
              return NotFound();
          }
            var jobOpening = await _context.JobOpenings.FindAsync(id);

            if (jobOpening == null)
            {
                return NotFound();
            }

            return jobOpening;
        }

        // PUT: api/JobOpening/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobOpening(int id, JobOpening jobOpening)
        {
            if (id != jobOpening.PositionId)
            {
                return BadRequest();
            }

            _context.Entry(jobOpening).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobOpeningExists(id))
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

        // POST: api/JobOpening
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobOpening>> PostJobOpening(JobOpening jobOpening)
        {
          if (_context.JobOpenings == null)
          {
              return Problem("Entity set 'EmployeeManagementContext.JobOpenings'  is null.");
          }
            _context.JobOpenings.Add(jobOpening);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobOpeningExists(jobOpening.PositionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobOpening", new { id = jobOpening.PositionId }, jobOpening);
        }

        // DELETE: api/JobOpening/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobOpening(int id)
        {
            if (_context.JobOpenings == null)
            {
                return NotFound();
            }
            var jobOpening = await _context.JobOpenings.FindAsync(id);
            if (jobOpening == null)
            {
                return NotFound();
            }

            _context.JobOpenings.Remove(jobOpening);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobOpeningExists(int id)
        {
            return (_context.JobOpenings?.Any(e => e.PositionId == id)).GetValueOrDefault();
        }
    }
}
