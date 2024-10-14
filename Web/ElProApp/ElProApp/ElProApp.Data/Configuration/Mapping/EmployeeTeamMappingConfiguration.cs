namespace ElProApp.Data.Configurations
{
    using ElProApp.Data.Models.Mappings;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeTeamMappingConfiguration : IEntityTypeConfiguration<EmployeeTeamMapping>
    {
        public void Configure(EntityTypeBuilder<EmployeeTeamMapping> builder)
        {
            builder.HasKey(et => new { et.EmployeeId, et.TeamId });

            builder
                .HasOne(et => et.Employee)
                .WithMany(e => e.TeamsEmployeeBelongsTo)
                .HasForeignKey(et => et.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(et => et.Team)
                .WithMany(t => t.EmployeesInTeam)
                .HasForeignKey(et => et.TeamId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
