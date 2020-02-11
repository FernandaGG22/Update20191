using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC1.Models;

namespace SalesWebMVC1.Data
{
    public class SalesWebMVC1Context : DbContext
    {
        public SalesWebMVC1Context (DbContextOptions<SalesWebMVC1Context> options)
            : base(options)
        {
        }

        public DbSet<SalesWebMVC1.Models.Department> Department { get; set; }
    }
}
