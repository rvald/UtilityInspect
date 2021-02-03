using Microsoft.EntityFrameworkCore;
using UtilityInspect.EmployeeService.Models;

namespace UtilityInspect.EmployeeService.Data
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasPostgresExtension("uuid-ossp")
                .Entity<Employee>()
                .Property( e => e.EmployeeID)
                .HasDefaultValueSql("uuid_generate_v4()");

        }
    }
}