namespace ElProApp.Data.Configurations
{
    using ElProApp.Data.Models.Mappings;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class JobDoneTeamMappingConfiguration : IEntityTypeConfiguration<JobDoneTeamMapping>
    {
        public void Configure(EntityTypeBuilder<JobDoneTeamMapping> builder)
        {
            builder.HasKey(jdtm => jdtm.Id);

            builder
                .HasOne(jdtm => jdtm.JobDone)
                .WithMany(jd => jd.TeamsDoTheJob)
                .HasForeignKey(jdtm => jdtm.JobDoneId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder
                .HasOne(jdtm => jdtm.Team)
                .WithMany(t => t.JobsDoneByTeam)
                .HasForeignKey(jdtm => jdtm.TeamId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
