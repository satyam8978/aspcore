using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspCorePractie.Data;
using AspCorePractie.Model;

namespace AspCorePractie.Pages.Emp
{

    public class IndexModel : PageModel
    {
        private readonly AspCorePractie.Data.EmpContext _context;

        public IndexModel(AspCorePractie.Data.EmpContext context)
        {
            _context = context;
        }

        public IList<emp> emp { get;set; }

        public async Task OnGetAsync()
        {
            emp = await _context.emp.ToListAsync();
        }
    }
}
