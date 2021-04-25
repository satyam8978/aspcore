using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspCorePractie.Data;
using AspCorePractie.Model;

namespace AspCorePractie.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class emps1Controller : ControllerBase
    {
        private readonly EmpContext _context;

        public emps1Controller(EmpContext context)
        {
            _context = context;
        }

        // GET: api/emps1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<emp>>> Getemp()
        {
            return await _context.emp.ToListAsync();
        }

        // GET: api/emps1/5
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

        // PUT: api/emps1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
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

        // POST: api/emps1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<emp>> Postemp(emp emp)
        {
            _context.emp.Add(emp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getemp", new { id = emp.id }, emp);
        }

        // DELETE: api/emps1/5
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
