using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_ren.Models;

namespace test_ren.Database
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Office> Offices { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
