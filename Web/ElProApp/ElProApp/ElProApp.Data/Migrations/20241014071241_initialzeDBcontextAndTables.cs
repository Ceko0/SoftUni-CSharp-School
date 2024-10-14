using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElProApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialzeDBcontextAndTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the building."),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the building with a minimum of 3 and a maximum of 50 characters."),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The location of the building with a minimum of 10 and a maximum of 100 characters.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the employee."),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The first name of the employee with a maximum of 20 characters."),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The last name of the employee with a maximum of 20 characters."),
                    Wages = table.Column<decimal>(type: "decimal(4,2)", nullable: false, comment: "The wages of the employee with up to 4 digits before the decimal point and up to 2 digits after."),
                    MoneyToTake = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The money the employee has to take, must be a positive value."),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key representing the team to which the employee belongs.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the job with a maximum of 50 characters."),
                    Price = table.Column<decimal>(type: "decimal(4,2)", nullable: false, comment: "The price of the job with up to 4 digits before the decimal point and up to 2 digits after.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jobsDone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the job done record"),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for the job being done"),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for the team that completed the job"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for the user responsible for the job"),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for the building where the job was performed."),
                    Quantity = table.Column<decimal>(type: "decimal(6,2)", nullable: false, comment: "Quantity of work completed"),
                    DaysForJob = table.Column<int>(type: "int", nullable: false, comment: "Number of days spent completing the job")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobsDone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key and unique identifier for the team"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The name of the team with a maximum length")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buildings");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "jobsDone");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
