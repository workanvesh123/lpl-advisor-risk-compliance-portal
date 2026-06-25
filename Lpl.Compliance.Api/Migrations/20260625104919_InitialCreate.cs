using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lpl.Compliance.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplianceCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RiskScore = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceCases", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ComplianceCases",
                columns: new[] { "Id", "AdvisorName", "ClientName", "CreatedDate", "RiskScore", "Status" },
                values: new object[,]
                {
                    { 1, "Ravi Kumar", "John Smith", new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, "New" },
                    { 2, "Priya Sharma", "Mary Johnson", new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, "In Review" },
                    { 3, "Anil Reddy", "Robert Brown", new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, "Pending Documents" },
                    { 4, "Sneha Rao", "Linda Davis", new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Approved" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceCases_CreatedDate",
                table: "ComplianceCases",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceCases_RiskScore",
                table: "ComplianceCases",
                column: "RiskScore");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceCases_Status",
                table: "ComplianceCases",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplianceCases");
        }
    }
}
