using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElProApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMappingAndMapingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "jobsDone");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "jobsDone");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "jobsDone");

            migrationBuilder.CreateTable(
                name: "buildingTeamMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildingTeamMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_buildingTeamMappings_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_buildingTeamMappings_teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "employeeTeamMappings",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for the employee."),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for the team."),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the mapping between Employee and Team.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeTeamMappings", x => new { x.EmployeeId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_employeeTeamMappings_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_employeeTeamMappings_teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "jobDoneTeamMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobDoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobDoneTeamMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobDoneTeamMappings_jobsDone_JobDoneId",
                        column: x => x.JobDoneId,
                        principalTable: "jobsDone",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_jobDoneTeamMappings_teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_jobsDone_JobId",
                table: "jobsDone",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_buildingTeamMappings_BuildingId",
                table: "buildingTeamMappings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_buildingTeamMappings_TeamId",
                table: "buildingTeamMappings",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_employeeTeamMappings_TeamId",
                table: "employeeTeamMappings",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_jobDoneTeamMappings_JobDoneId",
                table: "jobDoneTeamMappings",
                column: "JobDoneId");

            migrationBuilder.CreateIndex(
                name: "IX_jobDoneTeamMappings_TeamId",
                table: "jobDoneTeamMappings",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobsDone_jobs_JobId",
                table: "jobsDone",
                column: "JobId",
                principalTable: "jobs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobsDone_jobs_JobId",
                table: "jobsDone");

            migrationBuilder.DropTable(
                name: "buildingTeamMappings");

            migrationBuilder.DropTable(
                name: "employeeTeamMappings");

            migrationBuilder.DropTable(
                name: "jobDoneTeamMappings");

            migrationBuilder.DropIndex(
                name: "IX_jobsDone_JobId",
                table: "jobsDone");

            migrationBuilder.AddColumn<Guid>(
                name: "BuildingId",
                table: "jobsDone",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Foreign key for the building where the job was performed.");

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "jobsDone",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Foreign key for the team that completed the job");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "jobsDone",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Foreign key for the user responsible for the job");
        }
    }
}
