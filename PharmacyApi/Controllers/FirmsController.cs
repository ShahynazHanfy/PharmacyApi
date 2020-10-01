using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyApi.Authentication;
using PharmacyApi.Models;

namespace PharmacyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FirmsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Firms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Firm>>> GetFirm()
        {
            return await _context.Firm.ToListAsync();
        }
        [HttpGet]
        [Route("activeFirm")]
        public async Task<ActionResult<IEnumerable<Firm>>> GetActiveFirm()
        {
            return await _context.Firm.Where(n=>n.IsActive == true).ToListAsync();
        }
        // GET: api/Firms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Firm>> GetFirm(int id)
        {
            var firm = await _context.Firm.FindAsync(id);

            if (firm == null)
            {
                return NotFound();
            }

            return firm;
        }

        // PUT: api/Firms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFirm(int id, Firm firm)
        {
            if (id != firm.ID)
            {
                return BadRequest();
            }

            _context.Entry(firm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirmExists(id))
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

        // POST: api/Firms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Firm>> PostFirm(Firm firm)
        {
            _context.Firm.Add(firm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFirm", new { id = firm.ID }, firm);
        }

        // DELETE: api/Firms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Firm>> DeleteFirm(int id)
        {
            var firm = await _context.Firm.FindAsync(id);
            if (firm == null)
            {
                return NotFound();
            }

            _context.Firm.Remove(firm);
            await _context.SaveChangesAsync();

            return firm;
        }

        private bool FirmExists(int id)
        {
            return _context.Firm.Any(e => e.ID == id);
        }
    }
}
