﻿// <auto-generated />
using System;
using ElProApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElProApp.Data.Migrations.ElProAppDb
{
    [DbContext(typeof(ElProAppDbContext))]
    partial class ElProAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElProApp.Data.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("MoneyToTake")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<decimal>("Wages")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("acd24a8d-ee72-41c1-b485-55181b226727"),
                            EmployeeTeamId = new Guid("00000000-0000-0000-0000-000000000000"),
                            FirstName = "Georgi",
                            LastName = "Petrov",
                            MoneyToTake = 100.00m,
                            Wages = 80.00m
                        },
                        new
                        {
                            Id = new Guid("3ed03724-0a27-43d1-8689-abf8ca8e9751"),
                            EmployeeTeamId = new Guid("00000000-0000-0000-0000-000000000000"),
                            FirstName = "Spas",
                            LastName = "Georgiev",
                            MoneyToTake = 100.00m,
                            Wages = 90.00m
                        });
                });

            modelBuilder.Entity("ElProApp.Data.Models.EmployeeTeamMapping", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId", "EmployeeTeamId");

                    b.HasIndex("EmployeeTeamId");

                    b.ToTable("EmployeeTeamMappings");
                });

            modelBuilder.Entity("ElProApp.Data.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("ElProApp.Data.Models.EmployeeTeamMapping", b =>
                {
                    b.HasOne("ElProApp.Data.Models.Employee", "Employee")
                        .WithMany("EmployeeTeamsMapping")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElProApp.Data.Models.Team", "Team")
                        .WithMany("EmployeesMapping")
                        .HasForeignKey("EmployeeTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ElProApp.Data.Models.Employee", b =>
                {
                    b.Navigation("EmployeeTeamsMapping");
                });

            modelBuilder.Entity("ElProApp.Data.Models.Team", b =>
                {
                    b.Navigation("EmployeesMapping");
                });
#pragma warning restore 612, 618
        }
    }
}
