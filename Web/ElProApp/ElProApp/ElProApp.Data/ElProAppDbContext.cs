namespace ElProApp.Data
{
    using System.Reflection;
    using ElProApp.Data.Configurations;
    using ElProApp.Data.Models.Mappings;
    using ElProApp.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ElProAppDbContext : IdentityDbContext<IdentityUser>
    {
        public ElProAppDbContext(DbContextOptions<ElProAppDbContext> option)
            : base(option)
        {
        }

        public DbSet<Building> buildings { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Job> jobs { get; set; }
        public DbSet<JobDone> jobsDone { get; set; }
        public DbSet<Team> teams { get; set; }
        public DbSet<BuildingTeamMapping> buildingTeamMappings { get; set; }
        public DbSet<EmployeeTeamMapping> employeeTeamMappings { get; set; }
        public DbSet<JobDoneTeamMapping> jobDoneTeamMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new JobDoneConfiguration());
            modelBuilder.ApplyConfiguration(new BuildingConfiguration());
            modelBuilder.ApplyConfiguration(new JobDoneTeamMappingConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeTeamMappingConfiguration());
            modelBuilder.ApplyConfiguration(new BuildingTeamMappingConfiguration());
        }
    }
}
