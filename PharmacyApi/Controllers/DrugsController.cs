using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyApi.Authentication;
using PharmacyApi.DTO;
using PharmacyApi.Models;
using Microsoft.AspNetCore.Hosting;

namespace PharmacyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsController : ControllerBase
    {
        private IHostingEnvironment _env;
        private readonly ApplicationDbContext _context;

        public DrugsController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _env = env;
            _context = context;
        }

        // GET: api/Drugs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drug>>> GetDrug()
        {
            var drugs = await _context.Drug.ToListAsync();
            return drugs;
        }

        // GET: api/Drugs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drug>> GetDrug(int id)
        {
            var drug = await _context.Drug.FindAsync(id);

            if (drug == null)
            {
                return NotFound();
            }

            return drug;
        }

        // PUT: api/Drugs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrug(int id, Drug drug)
        {
            if (id != drug.ID)
            {
                return BadRequest();
            }

            _context.Entry(drug).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugExists(id))
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

        // POST: api/Drugs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Drug>> PostDrug(Drug drug)
        {
            
                _context.Drug.Add(drug);
            var drugID = await _context.SaveChangesAsync();
         
                //var lst = drug.drugDetails.ToList();

                //foreach (var item in lst)
                //{
                    DrugDetails drugDetails = new DrugDetails();
                    drugDetails.Exp_Date = drug.drugDetails.Exp_Date;
                    drugDetails.Code = drug.drugDetails.Code;
                    drugDetails.Prod_Date = drug.drugDetails.Prod_Date;
                    drugDetails.BarCode = drug.drugDetails.BarCode;
                    drugDetails.Quentity = drug.drugDetails.Quentity;
                    drugDetails.ReOrderLevel = drug.drugDetails.ReOrderLevel;
                    drugDetails.Size = drug.drugDetails.Size;
                    drugDetails.Strength = drug.drugDetails.Strength;
                    drugDetails.Pack = drug.drugDetails.Pack;
                    drugDetails.License = drug.drugDetails.License;
                    drugDetails.IsActive = drug.drugDetails.IsActive;
                    drugDetails.Price = drug.drugDetails.Price;
                    drugDetails.IsChecked = drug.drugDetails.IsChecked;
                    drugDetails.drugID = drugID;
                    drugDetails.pharmacyID = drug.drugDetails.pharmacyID;

                    _context.DrugDetails.Add(drugDetails);
                   await _context.SaveChangesAsync();
               // }
                return Ok();
            
        }

        // DELETE: api/Drugs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Drug>> DeleteDrug(int id)
        {
            var drug = await _context.Drug.FindAsync(id);
            if (drug == null)
            {
                return NotFound();
            }

            _context.Drug.Remove(drug);
            await _context.SaveChangesAsync();

            return drug;
        }

        private bool DrugExists(int id)
        {
            return _context.Drug.Any(e => e.ID == id);
        }

        [HttpGet]
        [Route("thera")]

        public async Task<ActionResult<IEnumerable<TheraGroup>>> GetThera()
        {
            return await _context.TheraGroup.ToListAsync();
        }
        [HttpGet]
        [Route("activethera")]

        public async Task<ActionResult<IEnumerable<TheraGroup>>> GetActiveThera()
        {
            return await _context.TheraGroup.Where(n=>n.IsActive == true).ToListAsync();
        }

        [HttpGet]
        [Route("therasub")]

        public async Task<ActionResult<IEnumerable<TheraSubGroup>>> GetTheraSub()
        {
            return await _context.TheraSubGroup.ToListAsync();
        }

        [HttpGet]
        [Route("therasubBYgroup/{Grpid}")]

        public IEnumerable<TheraSubGroup> GetTheraSubByGrpId(int Grpid)
        {
            var TheraSub = _context.TheraSubGroup.Where(x => x.TheraGroupID == Grpid&& x.IsActive==true).ToList();

            return TheraSub;
        }
        [HttpGet]
        [Route("forms")]

        public IEnumerable<FormDTO> GetForms()
        {
            return _context.Form.Select(f => new FormDTO
            {
                Code = f.Code,
                ID = f.ID,
                Name = f.Name,
                PHFORM = f.PHFORM
            }).ToList();
        }

        [HttpGet]
        [Route("firms")]

        public IEnumerable<FirmDTO> GetFirms()
        {
            var firms = _context.Firm.Select(f => new FirmDTO
            {
                Name = f.Name,
                ID = f.ID,
                Code = f.Code
            }).ToList();
            return firms;
        }

        [HttpGet]
        [Route("country")]

        public IEnumerable<CountryDTO> GetCountries()
        {
            return _context.Country.Select(c => new CountryDTO
            {
                Code = c.Code,
                ID = c.ID,
                Name = c.Name
            })
                .ToList();
        }

        [HttpGet]
        [Route("activecountry")]

        public IEnumerable<CountryDTO> GetAllActiveCountries()
        {
            return _context.Country.Where(m=>m.IsActive==true).Select(c => new CountryDTO
            {
                Code = c.Code,
                ID = c.ID,
                Name = c.Name
            })
                .ToList();
        }

        [HttpGet]
        [Route("unit")]

        public IEnumerable<UnitDTO> GetUnits()
        {
            var units = _context.Unit.
                Select(u => new UnitDTO
                {
                    Code = u.Code,
                    Description = u.Description,
                    ID = u.ID,
                    Name = u.Name
                }).
                ToList();
            return units;
        }
        [HttpGet]
        [Route("activeunit")]

        public IEnumerable<UnitDTO> GetAllActiveUnits()
        {
            var units = _context.Unit.Where(x=>x.IsActive == true).
                Select(u => new UnitDTO
                {
                    Code = u.Code,
                    Description = u.Description,
                    ID = u.ID,
                    Name = u.Name
                }).
                ToList();
            return units;
        }

        [HttpGet]
        [Route("ROAD")]
        public IEnumerable<RoadDTO> GetROAD()
        {
            return _context.ROAD.Select(r => new RoadDTO
            {
                Name = r.Name,
                ID = r.ID,
                Description = r.Description,
                Code = r.Code
            }
                ).ToList();
        }

        [Route("ActiveROAD")]
        public IEnumerable<RoadDTO> GetAllActiveROAD()
        {
            return _context.ROAD.Where(x=>x.IsActive).Select(r => new RoadDTO
            {
                Name = r.Name,
                ID = r.ID,
                Description = r.Description,
                Code = r.Code
            }
                ).ToList();
        }
        [HttpPost]
        [Route("api/Drugs/UploadImage")]
        public ActionResult UploadImage(IFormFile file)
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        [Route("getImage/{ImageName}")]
        public IActionResult ImageGet(string ImageName)
        {
            //ImageName = "#6M@CX79)G77LT&9F&G8^P0XYA2^YNE9J2GO^WCA.jpg";
            if (ImageName == null)
                return Content("filename not present");

            var path = _env.WebRootFileProvider.GetFileInfo("/images/" + ImageName)?.PhysicalPath;
                //(Path.Combine(
                //           Directory.GetCurrentDirectory(),
                //           "wwwroot/images", ImageName));

            var memory = new MemoryStream();
            var ext = System.IO.Path.GetExtension(path);
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            return File(memory, contentType, Path.GetFileName(path));
        }

      

        [Route("pledge")]

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pledge>>> GetPledges()
        {
            var Pledges = await _context.Pledge.ToListAsync();
            return Pledges;
        }

        [Route("Supplier")]

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            var Suppliers = await _context.Supplier.ToListAsync();
            return Suppliers;
        }





    }
}
