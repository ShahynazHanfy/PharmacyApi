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
        [Route("GetDrugDetails/{pharmacyId}")]
        public IEnumerable<DrugsDetailsDTO> GetDrugDetailsByPharmacyId(int pharmacyId)
        {
            var drugsDetails = _context.DrugDetails.ToList();
            var drugs = _context.Drug.ToList();

            var lstDrugs = (from drug in drugs
                            join details in drugsDetails on drug.ID equals details.drugID
                            where details.pharmacyLoggedInID == pharmacyId
                            select new DrugsDetailsDTO
                            {
                                TradeName = drug.TradeName,
                                GenericName = drug.GenericName,
                                Img = drug.Img,
                                Strength = details.Strength,
                                BarCode = details.BarCode,
                                Code = details.Code,
                                Exp_Date = details.Exp_Date,
                                Prod_Date = details.Prod_Date,
                                IsActive = details.IsActive,
                                Price = details.Price,
                                IsChecked = details.IsChecked,
                                License = details.License,
                                Pack = details.Pack,
                                Quentity = details.Quentity,
                                ReOrderLevel = details.ReOrderLevel,
                                Size = details.Size,
                            }).ToList();
            return lstDrugs;

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
        public  ActionResult<DrugDetails> PostDrugDetails(DrugDetails drugDetails)
        {
            _context.DrugDetails.Add(drugDetails);
             _context.SaveChanges();

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
