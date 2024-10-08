namespace ElProApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    using Models;
    
    public class JobDoneConfiguration : IEntityTypeConfiguration<JobDone>
    {
        public void Configure(EntityTypeBuilder<JobDone> builder)
        {
            builder
                .HasKey(jd => jd.Id);

            builder
                .Property(jd => jd.Quantity)
                .IsRequired()
                .HasColumnType("decimal(6, 2)");

            builder
                .Property(jd => jd.DaysForJobDone)
                .IsRequired()
                .HasColumnType("integer");
        }
    }
}
