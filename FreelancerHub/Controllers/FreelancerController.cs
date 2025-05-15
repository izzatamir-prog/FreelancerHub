using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreelancerHub.Conn;
using FreelancerHub.Models;
using System.Linq;

namespace FreelancerHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FreelancerController : ControllerBase
    {
        private readonly FreelancerDbContext _context;

        public FreelancerController(FreelancerDbContext context)
        {
            _context = context;
        }

        // GET: api/freelancer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Freelancer>>> GetFreelancers()
        {
            return await _context.Freelancers
                .Include(f => f.Skillsets)
                .Include(f => f.Hobbies)
                .Where(f => !f.IsArchive)
                .ToListAsync();
        }

        // GET: api/freelancer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Freelancer>> GetFreelancer(int id)
        {
            var freelancer = await _context.Freelancers
                .Include(f => f.Skillsets)
                .Include(f => f.Hobbies)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (freelancer == null)
                return NotFound();

            return freelancer;
        }

        // POST: api/freelancer
        [HttpPost]
        public async Task<ActionResult<Freelancer>> PostFreelancer(Freelancer freelancer)
        {
            _context.Freelancers.Add(freelancer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFreelancer), new { id = freelancer.Id }, freelancer);
        }

        // PUT: api/freelancer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFreelancer(int id, Freelancer updated)
        {
            if (id != updated.Id)
                return BadRequest();

            _context.Entry(updated).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/freelancer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelancer(int id)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer == null)
                return NotFound();

            _context.Freelancers.Remove(freelancer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("archive/{id}")]
        public async Task<IActionResult> ArchiveFreelancer(int id)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer == null)
                return NotFound();

            freelancer.IsArchive = true;
            await _context.SaveChangesAsync();

            return Ok("Freelancer archived.");
        }

        [HttpPatch("unarchive/{id}")]
        public async Task<IActionResult> UnarchiveFreelancer(int id)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer == null)
                return NotFound();

            freelancer.IsArchive = false;
            await _context.SaveChangesAsync();

            return Ok("Freelancer unarchived.");
        }

    }
}
