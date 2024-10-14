namespace ElProApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    using static Common.EntityValidationConstants.Employee;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.Property(e => e.Wages)
                .IsRequired()
                .HasColumnType("decimal(4, 2)");

            builder
                .Property(e => e.MoneyToTake)
                .HasColumnType("decimal(18, 2)");

        }
    }
}
