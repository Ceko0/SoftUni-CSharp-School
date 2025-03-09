namespace MusicHub.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    using static EntityValidationConstants.Producer;

    public class ProducerEntityConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasMaxLength(ProducerNameMaxLength)
                .IsRequired()
                .IsUnicode();

            builder
                .Property(p => p.Pseudonym)
                .IsRequired(false)
                .IsUnicode();

            builder
                .Property(p => p.PhoneNumber)
                .HasMaxLength(ProducerPhoneNumberMaxLength)
                .IsRequired(false)
                .IsUnicode();

 

        }
    }
}
