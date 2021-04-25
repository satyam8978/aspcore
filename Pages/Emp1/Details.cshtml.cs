using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspCorePractie.Data;
using AspCorePractie.Model;

namespace AspCorePractie.Pages.Emp1
{
    public class DetailsModel : PageModel
    {
        private readonly AspCorePractie.Data.EmpContext _context;

        public DetailsModel(AspCorePractie.Data.EmpContext context)
        {
            _context = context;
        }

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
    }
}
