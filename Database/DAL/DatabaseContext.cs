using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Clockin> Clockins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Site> Sites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeSite>()
                .HasKey(es => new { es.EmployeeId, es.SiteId });

            modelBuilder.Entity<Site>().HasIndex(e => e.Name).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
