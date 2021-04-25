using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspCorePractie.Data;
using AspCorePractie.Model;
using Microsoft.AspNetCore.Authorization;

namespace AspCorePractie.Pages.Emp
{
   
    public class CreateModel : PageModel
    {

        private readonly AspCorePractie.Data.EmpContext _context;

        public CreateModel(AspCorePractie.Data.EmpContext context)
        {
            _context = context;
        }
       
       
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public emp emp { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        // POST: api/Toadd
#pragma warning disable MVC1002 // Route attributes cannot be applied to page handler methods.
        [HttpPost]
#pragma warning restore MVC1002 // Route attributes cannot be applied to page handler methods.
     
        public async Task<IActionResult> OnPostAsync()
        {
     
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.emp.Add(emp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
