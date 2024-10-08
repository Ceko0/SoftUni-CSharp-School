namespace ElProApp.Data.Configurations.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models.Mapping;

    public class BuildingTeamMappingConfiguration : IEntityTypeConfiguration<BuildingTeamMapping>
    {
        public void Configure(EntityTypeBuilder<BuildingTeamMapping> builder)
        {
            builder
                .HasKey(btm => new
                {
                    btm.BuildingId,
                    btm.TeamId
                });

            builder
                .HasOne(btm => btm.Building)
                .WithMany(b => b.TeamMappings)
                .HasForeignKey(b => b.BuildingId)
                .IsRequired();

            builder
                .HasOne(btm => btm.Team)
                .WithMany(t => t.BuildingsMapping)
                .HasForeignKey(t => t.TeamId)
                .IsRequired();

        }
    }
}
