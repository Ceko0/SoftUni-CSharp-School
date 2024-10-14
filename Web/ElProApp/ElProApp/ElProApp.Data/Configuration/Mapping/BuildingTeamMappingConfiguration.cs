namespace ElProApp.Data.Configurations
{
    using ElProApp.Data.Models.Mappings;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BuildingTeamMappingConfiguration : IEntityTypeConfiguration<BuildingTeamMapping>
    {
        public void Configure(EntityTypeBuilder<BuildingTeamMapping> builder)
        {
            builder.HasKey(btm => btm.Id);

            builder
                .HasOne(btm => btm.Building)
                .WithMany(b => b.TeamsOnBuilding)
                .HasForeignKey(btm => btm.BuildingId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder
                .HasOne(btm => btm.Team)
                .WithMany(t => t.BuildingWhitTeam)
                .HasForeignKey(btm => btm.TeamId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
