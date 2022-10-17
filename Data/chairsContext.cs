using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using chairs.Models;

namespace chairs.Data
{
    public class chairsContext : DbContext
    {
        public chairsContext (DbContextOptions<chairsContext> options)
            : base(options)
        {
        }

        public DbSet<chairs.Models.Chairs> Chairs { get; set; } // getting the databse ready
    }
}
