using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B13_MS_School.Data
{
    public class Table : DbContext
    {
        public Table(DbContextOptions<Table> options) : base(options)
        {
        }

        public DbSet<B13_MS_School.Models.List> Login { get; set; }
        public DbSet<B13_MS_School.Models.Students> Students { get; set; }
        public DbSet<B13_MS_School.Models.Student> Student { get; set; }
        public DbSet<B13_MS_School.Models.Payment> Payment { get; set; }
        public DbSet<B13_MS_School.Models.Schedule> Schedule { get; set; }
    }
}
