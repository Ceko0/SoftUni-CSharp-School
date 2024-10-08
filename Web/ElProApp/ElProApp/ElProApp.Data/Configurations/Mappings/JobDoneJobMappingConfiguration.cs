namespace ElProApp.Data.Configurations.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.Mapping;
    
    public class JobDoneJobMappingConfiguration : IEntityTypeConfiguration<JobDoneJobMapping>
    {
        public void Configure(EntityTypeBuilder<JobDoneJobMapping> builder)
        {
            builder
                .HasKey(jdjm => new
                {
                    jdjm.JobId,
                    jdjm.JobDoneId
                });

            builder
                .HasOne(jdjm => jdjm.Job)
                .WithMany(j => j.JobDoneMapping)
                .HasForeignKey(jdjm => jdjm.JobId)
                .IsRequired();

            builder
                .HasOne(jdjm => jdjm.JobDone)
                .WithMany(jd => jd.JobMapping)
                .HasForeignKey(jdjm => jdjm.JobDoneId)
                .IsRequired();
        }
    }
}
