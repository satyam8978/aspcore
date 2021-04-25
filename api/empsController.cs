using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspCorePractie.Data;
using AspCorePractie.Model;
using Microsoft.AspNetCore.Authorization;
using AspCorePractie.ActionFilters;

namespace AspCorePractie.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class empsController : ControllerBase
    {
        private readonly EmpContext _context;

        public empsController(EmpContext context)
        {
            _context = context;
        }

        // GET: api/emps
       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<emp>>> Getemp()
        {
            return await _context.emp.ToListAsync();
        }

        // GET: api/emps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<emp>> Getemp(int id)
        {
            var emp = await _context.emp.FindAsync(id);

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }

        // PUT: api/emps/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
    //      [ServiceFilter(typeof(Validationfilters))]
        public async Task<IActionResult> Putemp(int id, emp emp)
        {
            if (id != emp.id)
            {
                return BadRequest();
            }

            _context.Entry(emp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!empExists(id))
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

        // POST: api/emps
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
       
        public async Task<ActionResult<emp>> Postemp(emp emp)
        {
            _context.emp.Add(emp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getemp", new { id = emp.id }, emp);
        }

        // DELETE: api/emps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<emp>> Deleteemp(int id)
        {
            var emp = await _context.emp.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }

            _context.emp.Remove(emp);
            await _context.SaveChangesAsync();

            return emp;
        }

        private bool empExists(int id)
        {
            return _context.emp.Any(e => e.id == id);
        }
    }
}
