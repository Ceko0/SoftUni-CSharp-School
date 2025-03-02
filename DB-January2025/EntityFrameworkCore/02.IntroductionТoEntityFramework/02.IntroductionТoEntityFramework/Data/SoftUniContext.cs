namespace SoftUni.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public partial class SoftUniContext : DbContext
    {
        public SoftUniContext()
        {
        }

        public SoftUniContext(DbContextOptions<SoftUniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Town> Towns { get; set; } = null!;
        public virtual DbSet<EmployeeProject> EmployeesProjects { get; set; } = null!;

        protected string ConnectionString = "Server=DESKTOP-4KOOIQJ;Database=SoftUni;Integrated Security=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity
                    .Property(e => e.AddressId)
                    .HasColumnName("AddressID");

                entity
                    .Property(e => e.AddressText)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity
                    .Property(e => e.TownId)
                    .HasColumnName("TownID");

                entity
                    .HasOne(d => d.Town)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.TownId)
                    .HasConstraintName("FK_Addresses_Towns");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity
                    .Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity
                    .Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity
                    .Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity
                    .HasOne(d => d.Manager)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departments_Employees");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity
                    .Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID");

                entity
                    .Property(e => e.AddressId)
                    .HasColumnName("AddressID");

                entity
                    .Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID");

                entity
                    .Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity
                    .Property(e => e.HireDate)
                    .HasColumnType("smalldatetime");

                entity
                    .Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity
                    .Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity
                    .Property(e => e.ManagerId)
                    .HasColumnName("ManagerID");

                entity
                    .Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity
                    .Property(e => e.Salary)
                    .HasColumnType("decimal(15, 4)");

                entity
                    .HasOne(d => d.Address)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Employees_Addresses");

                entity
                    .HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Departments");

                entity
                    .HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Employees_Employees");

                entity
                    .HasMany(d => d.EmployeesProjects)
                    .WithOne(ep => ep.Employee)
                    .HasForeignKey(ep => ep.EmployeeId);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity
                    .Property(e => e.ProjectId)
                    .HasColumnName("ProjectID");

                entity
                    .Property(e => e.Description)
                    .HasColumnType("ntext");

                entity
                    .Property(e => e.EndDate)
                    .HasColumnType("smalldatetime");

                entity
                    .Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity
                    .Property(e => e.StartDate)
                    .HasColumnType("smalldatetime");

                entity
                    .HasMany(p => p.EmployeesProjects)
                    .WithOne(ep => ep.Project)
                    .HasForeignKey(ep => ep.ProjectId);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity
                    .Property(e => e.TownId)
                    .HasColumnName("TownID");

                entity
                    .Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity
                    .HasKey(e => new { e.EmployeeId, e.ProjectId });

                entity
                    .Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID");

                entity
                    .Property(e => e.ProjectId)
                    .HasColumnName("ProjectID");

                entity
                    .HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeesProjects)
                    .HasForeignKey(d => d.EmployeeId);

                entity
                    .HasOne(d => d.Project)
                    .WithMany(p => p.EmployeesProjects)
                    .HasForeignKey(d => d.ProjectId);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
