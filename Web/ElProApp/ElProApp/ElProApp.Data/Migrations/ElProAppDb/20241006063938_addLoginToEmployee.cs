using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElProApp.Data.Migrations.ElProAppDb
{
    /// <inheritdoc />
    public partial class addLoginToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("3ed03724-0a27-43d1-8689-abf8ca8e9751"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("acd24a8d-ee72-41c1-b485-55181b226727"));

            migrationBuilder.AddColumn<string>(
                name: "LoginId",
                table: "Employees",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeeTeamId", "FirstName", "LastName", "MoneyToTake", "Wages" },
                values: new object[,]
                {
                    { new Guid("3ed03724-0a27-43d1-8689-abf8ca8e9751"), new Guid("00000000-0000-0000-0000-000000000000"), "Spas", "Georgiev", 100.00m, 90.00m },
                    { new Guid("acd24a8d-ee72-41c1-b485-55181b226727"), new Guid("00000000-0000-0000-0000-000000000000"), "Georgi", "Petrov", 100.00m, 80.00m }
                });
        }
    }
}
