namespace ElProApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static Common.EntityValidationConstants.job;

    public class Job : IEntityTypeConfiguration<Models.Job>
    {

        public void Configure(EntityTypeBuilder<Models.Job> builder)
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
                .HasColumnType("decimal(6, 2)");
        }
    }
}
