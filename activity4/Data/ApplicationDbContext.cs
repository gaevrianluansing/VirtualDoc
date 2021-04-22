using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using activity4.Models;
using Microsoft.EntityFrameworkCore;

namespace activity4.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
        }
        public DbSet<Doctorsform> Doctorsforms { get; set; }

        public DbSet<Patient> Patients { get; set; }
    }
}
