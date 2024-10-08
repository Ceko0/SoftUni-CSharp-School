namespace ElProApp.Data.Configurations.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models.Mapping;

    public class EmployeeTeamMappingConfiguration : IEntityTypeConfiguration<EmployeeTeamMapping>
    {
        public void Configure(EntityTypeBuilder<EmployeeTeamMapping> builder)
        {
            builder
                .HasKey(tm => new
                {
                    tm.EmployeeId, EmployeeTeamId = tm.TeamId
                });

            builder
                .HasOne(tm => tm.Employee)
                .WithMany(e => e.TeamsMapping)
                .HasForeignKey(tm => tm.EmployeeId)
                .IsRequired();

            builder
                .HasOne(tm => tm.Team)
                .WithMany(et => et.EmployeesMapping)
                .HasForeignKey(tm => tm.TeamId)
                .IsRequired();
        }
    }
}