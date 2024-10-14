namespace ElProApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    using static Common.EntityValidationConstants.Building;

    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(BuildingNameMaxLength);

            builder
                .Property(b => b.Location)
                .IsRequired()
                .HasMaxLength(LocationMaxLength);
        }
    }
}
