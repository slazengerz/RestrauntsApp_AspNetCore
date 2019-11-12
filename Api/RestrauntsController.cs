using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestrauntsDataNetCore;

namespace RestrauntsAgain.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestrauntsController : ControllerBase
    {
        private readonly RestrauntsDbContext _context;

        public RestrauntsController(RestrauntsDbContext context)
        {
            _context = context;
        }

        // GET: api/Restraunts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restraunt>>> GetRestraunts()
        {
            return await _context.Restraunts.ToListAsync();

        }

        //// GET: api/Restraunts
        //[HttpGet]
        //public  IEnumerable<Restraunt> GetRestraunts()
        //{
        //    var restraunts = from r in _context.Restraunts
        //                      select r;

        //    return restraunts.ToList();

        //}

        // GET: api/Restraunts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restraunt>> GetRestraunt(int id)
        {
            var restraunt = await _context.Restraunts.FindAsync(id);

            if (restraunt == null)
            {
                return NotFound();
            }

            return restraunt;
        }

        // PUT: api/Restraunts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestraunt(int id, Restraunt restraunt)
        {
            if (id != restraunt.Id)
            {
                return BadRequest();
            }

            _context.Entry(restraunt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestrauntExists(id))
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

        // POST: api/Restraunts
        [HttpPost]
        public async Task<ActionResult<Restraunt>> PostRestraunt(Restraunt restraunt)
        {
            _context.Restraunts.Add(restraunt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestraunt", new { id = restraunt.Id }, restraunt);
        }

        // DELETE: api/Restraunts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restraunt>> DeleteRestraunt(int id)
        {
            var restraunt = await _context.Restraunts.FindAsync(id);
            if (restraunt == null)
            {
                return NotFound();
            }

            _context.Restraunts.Remove(restraunt);
            await _context.SaveChangesAsync();

            return restraunt;
        }

        private bool RestrauntExists(int id)
        {
            return _context.Restraunts.Any(e => e.Id == id);
        }
    }
}
