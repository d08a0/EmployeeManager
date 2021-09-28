using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Db
{
    public class EmployeeManagerDbContext : DbContext
    {
        public EmployeeManagerDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }

    }
}