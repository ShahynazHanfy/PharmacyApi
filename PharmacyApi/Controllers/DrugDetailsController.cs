using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyApi.Authentication;
using PharmacyApi.DTO;
using PharmacyApi.Models;
using PharmacyApi.ViewModel;

namespace PharmacyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DrugDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DrugDetails
        [HttpGet]
        [Route("GetDrugDetails")]
        public IEnumerable<DrugsDetailsDTO> GetDrugDetails()
        {
            var drugsDetails = _context.DrugDetails.FirstOrDefault();
            var drugs =  _context.Drug.FirstOrDefault();
            var  Details = _context.DrugDetails.Select(d=>new DrugsDetailsDTO
            {
                TradeName = drugs.TradeName,
                GenericName = drugs.GenericName,
                Img = drugs.Img,
                Strength = drugsDetails.Strength,
                BarCode = drugsDetails.BarCode,
                Code = drugsDetails.Code,
                Exp_Date = drugsDetails.Exp_Date,
                Prod_Date = drugsDetails.Prod_Date,
                IsActive = drugsDetails.IsActive,
                IsChecked = drugsDetails.IsChecked,
                License = drugsDetails.License,
                Pack = drugsDetails.Pack,
                Quentity = drugsDetails.Quentity,
                ReOrderLevel = drugsDetails.ReOrderLevel,
                Size = drugsDetails.Size

            }).ToList();
            return Details;
            //return await _context.DrugDetails.ToListAsync();
        }

        // GET: api/DrugDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrugDetails>> GetDrugDetails(int id)
        {
            var drugDetails = await _context.DrugDetails.FindAsync(id);

            if (drugDetails == null)
            {
                return NotFound();
            }

            return drugDetails;
        }

        // PUT: api/DrugDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrugDetails(int id, DrugDetails drugDetails)
        {
            if (id != drugDetails.ID)
            {
                return BadRequest();
            }

            _context.Entry(drugDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugDetailsExists(id))
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

        // POST: api/DrugDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DrugDetails>> PostDrugDetails(DrugDetails drugDetails)
        {
            _context.DrugDetails.Add(drugDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrugDetails", new { id = drugDetails.ID }, drugDetails);
        }

        // DELETE: api/DrugDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DrugDetails>> DeleteDrugDetails(int id)
        {
            var drugDetails = await _context.DrugDetails.FindAsync(id);
            if (drugDetails == null)
            {
                return NotFound();
            }

            _context.DrugDetails.Remove(drugDetails);
            await _context.SaveChangesAsync();

            return drugDetails;
        }

        private bool DrugDetailsExists(int id)
        {
            return _context.DrugDetails.Any(e => e.ID == id);
        }
    }
}
