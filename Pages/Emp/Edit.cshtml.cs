using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCorePractie.Data;
using AspCorePractie.Model;
using Microsoft.AspNetCore.Authorization;

namespace AspCorePractie.Pages.Emp
{

    
    public class EditModel : PageModel
    {
        private readonly AspCorePractie.Data.EmpContext _context;

        public EditModel(AspCorePractie.Data.EmpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public emp emp { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            emp = await _context.emp.FirstOrDefaultAsync(m => m.id == id);

            if (emp == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(emp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!empExists(emp.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool empExists(int id)
        {
            return _context.emp.Any(e => e.id == id);
        }
    }
}
