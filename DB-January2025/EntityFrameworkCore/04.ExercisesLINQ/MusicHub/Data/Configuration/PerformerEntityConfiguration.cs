namespace MusicHub.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    using static EntityValidationConstants.Performer;

    public class PerformerEntityConfiguration : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.FirstName)
                .HasMaxLength(PerformerFirstNameMaxLength)
                .IsRequired();

            builder
                .Property(p => p.LastName)
                .HasMaxLength(PerformerLastNameMaxLength)
                .IsRequired();

            builder
                .Property(p => p.Age)
                .IsRequired();

            builder
                .Property(p => p.NetWorth)
                .IsRequired();


        }
    }
}
