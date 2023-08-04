using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Models;
using Pharmacy.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PharmacyController : ControllerBase
    {

        private readonly ApiDBContext _context;

        public PharmacyController(ApiDBContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Pharmacies.ToListAsync());
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(PharmacyModel pharmacy)
        {
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {

            return Ok();
        }

        [HttpPatch("{Pharmacy}")]
        public IActionResult Patch(PharmacyModel pharmacy)
        {
            return Ok();
        }
    }
}

