using System.Reflection;
using CinemaApp.Data.Models;

namespace CinemaApp.Data
{
    using Microsoft.EntityFrameworkCore;

    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
        {

        }

        public CinemaDbContext(DbContextOptions option)
        : base(option)
        {

        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
