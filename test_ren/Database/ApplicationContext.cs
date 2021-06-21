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

        public ApplicationContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}
