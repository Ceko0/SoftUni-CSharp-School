namespace ElProApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    using static Common.EntityValidationConstants.Job;

    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder
                .HasKey(j => j.Id);

            builder
                .Property(j => j.Name)
                .IsRequired()
                .HasMaxLength(nameMaxLength);

            builder
                .Property(j => j.Price)
                .IsRequired()
                .HasColumnType("decimal(4, 2)");
        }
    }
}
