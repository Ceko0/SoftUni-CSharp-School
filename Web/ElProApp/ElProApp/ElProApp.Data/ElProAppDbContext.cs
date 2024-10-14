namespace ElProApp.Data
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    
    using Models;

    public class ElProAppDbContext : DbContext
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
