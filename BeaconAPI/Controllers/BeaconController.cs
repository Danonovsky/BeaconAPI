using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeaconAPI.DAL;
using BeaconAPI.Entities;

namespace BeaconAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeaconController : ControllerBase
    {
        private readonly MyContext _context;

        public BeaconController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Beacon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beacon>>> GetBeacons()
        {
            return await _context.Beacons.ToListAsync();
        }

        // GET: api/Beacon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beacon>> GetBeacon(Guid id)
        {
            var beacon = await _context.Beacons.FindAsync(id);

            if (beacon == null)
            {
                return NotFound();
            }

            return beacon;
        }

        // PUT: api/Beacon/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeacon(Guid id, Beacon beacon)
        {
            if (id != beacon.Id)
            {
                return BadRequest();
            }

            _context.Entry(beacon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeaconExists(id))
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

        // POST: api/Beacon
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beacon>> PostBeacon(Beacon beacon)
        {
            _context.Beacons.Add(beacon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeacon", new { id = beacon.Id }, beacon);
        }

        // DELETE: api/Beacon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeacon(Guid id)
        {
            var beacon = await _context.Beacons.FindAsync(id);
            if (beacon == null)
            {
                return NotFound();
            }

            _context.Beacons.Remove(beacon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeaconExists(Guid id)
        {
            return _context.Beacons.Any(e => e.Id == id);
        }
    }
}
