namespace ElProApp.Data.Configurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Common.EntityValidationConstants.Employee;
    using Models;
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasKey(e => e.Id);
            builder
                .Property(e => e.LoginId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.Property(e => e.Wages)
                .IsRequired()
                .HasColumnType("decimal(6, 2)");

            builder
                .Property(e => e.MoneyToTake)
                .HasColumnType("decimal(6, 2)");
            builder.Property(e => e.LoginId);

        }

        private List<Employee> SeedEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Georgi",
                    LastName = "Petrov",
                    Wages = 80.00m,
                    MoneyToTake = 100.00m,

                },
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Spas",
                    LastName = "Georgiev",
                    Wages = 90.00m,
                    MoneyToTake = 100.00m,
                }
            };

            return employees;
        }
    }
}