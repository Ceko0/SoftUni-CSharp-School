using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ElProApp.Data.Models;
namespace ElProApp.Data.Configurations.relationship
{
    public class EmployeeTeamMappingConfiguration : IEntityTypeConfiguration<EmployeeTeamMapping>
    {
        public void Configure(EntityTypeBuilder<EmployeeTeamMapping> builder)
        {
            builder
                .HasKey(tm => new
                {
                    tm.EmployeeId,
                    tm.EmployeeTeamId
                });

            builder
                .HasOne(tm => tm.Employee)
                .WithMany(e => e.EmployeeTeamsMapping)
                .HasForeignKey(tm => tm.EmployeeId)
                .IsRequired();

            builder
                .HasOne(tm => tm.Team)
                .WithMany(et => et.EmployeesMapping)
                .HasForeignKey(tm => tm.EmployeeTeamId)
                .IsRequired();
        }
    }
}