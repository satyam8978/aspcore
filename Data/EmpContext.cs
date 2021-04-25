using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspCorePractie.Model;

namespace AspCorePractie.Data
{
    public class EmpContext : DbContext
    {
        public EmpContext (DbContextOptions<EmpContext> options)
            : base(options)
        {
        }

        public DbSet<AspCorePractie.Model.emp> emp { get; set; }
    }
}
