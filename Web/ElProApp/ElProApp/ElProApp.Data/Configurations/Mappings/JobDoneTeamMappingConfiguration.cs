namespace ElProApp.Data.Configurations.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.Mapping;

    public class JobDoneTeamMappingConfiguration : IEntityTypeConfiguration<JobDoneTeamMapping>
    {
        public void Configure(EntityTypeBuilder<JobDoneTeamMapping> builder)
        {
            builder
                .HasKey(jtm => new
                {
                    jtm.JobDoneId,
                    jtm.TeamId
                });

            builder
                .HasOne(jdtm => jdtm.JobDone)
                .WithMany(jd => jd.TeamMapping)
                .HasForeignKey(jd => jd.JobDoneId)
                .IsRequired();

            builder
                .HasOne(jdtm => jdtm.Team)
                .WithMany(t => t.JobDoneMapping)
                .HasForeignKey(t => t.TeamId)
                .IsRequired();
        }
    }
}
