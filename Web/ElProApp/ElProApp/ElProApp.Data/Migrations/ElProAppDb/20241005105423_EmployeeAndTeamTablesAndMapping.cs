using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElProApp.Data.Migrations.ElProAppDb
{
    /// <inheritdoc />
    public partial class EmployeeAndTeamTablesAndMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Wages = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    MoneyToTake = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    EmployeeTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTeamMappings",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTeamMappings", x => new { x.EmployeeId, x.EmployeeTeamId });
                    table.ForeignKey(
                        name: "FK_EmployeeTeamMappings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTeamMappings_Teams_EmployeeTeamId",
                        column: x => x.EmployeeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeeTeamId", "FirstName", "LastName", "MoneyToTake", "Wages" },
                values: new object[,]
                {
                    { new Guid("3ed03724-0a27-43d1-8689-abf8ca8e9751"), new Guid("00000000-0000-0000-0000-000000000000"), "Spas", "Georgiev", 100.00m, 90.00m },
                    { new Guid("acd24a8d-ee72-41c1-b485-55181b226727"), new Guid("00000000-0000-0000-0000-000000000000"), "Georgi", "Petrov", 100.00m, 80.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTeamMappings_EmployeeTeamId",
                table: "EmployeeTeamMappings",
                column: "EmployeeTeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTeamMappings");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
