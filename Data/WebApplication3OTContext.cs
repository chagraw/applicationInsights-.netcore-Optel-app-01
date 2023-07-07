using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3OT.Models;

namespace WebApplication3OT.Data
{
    public class WebApplication3OTContext : DbContext
    {
        public WebApplication3OTContext (DbContextOptions<WebApplication3OTContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication3OT.Models.Employee> Employees { get; set; } = default!;
    }
}
