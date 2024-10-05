using ElProApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElProApp.Data.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .HasKey(et => et.Id);

            builder
                .Property(et => et.Name)
                .IsRequired();
        }
    }
}