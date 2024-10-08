namespace ElProApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    using Models;
    using Models.Mapping;

    public class ElProAppDbContext(DbContextOptions<ElProAppDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<EmployeeTeamMapping> EmployeeTeamMappings { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<BuildingTeamMapping> BuildingsTeamMappings { get; set; } = null!;
        public virtual DbSet<JobDone> JobDone { get; set; } = null!;
        public virtual DbSet<JobDoneTeamMapping> JobDoneTeamMappings { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}