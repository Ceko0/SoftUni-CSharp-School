using System.Reflection;
using ElProApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ElProApp.Data
{
    public class ElProAppDbContext(DbContextOptions<ElProAppDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<EmployeeTeamMapping> EmployeeTeamMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}