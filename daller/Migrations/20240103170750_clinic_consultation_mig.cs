using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace daller.Migrations
{
    /// <inheritdoc />
    public partial class clinic_consultation_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClinicConsultations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultMotiveMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedLocationIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicConsultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicConsultations_Locations_SelectedLocationIndex",
                        column: x => x.SelectedLocationIndex,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClinicConsultations",
                columns: new[] { "Id", "ConsultMotiveMessage", "CreatedTime", "SelectedLocationIndex", "Url" },
                values: new object[,]
                {
                    { 1, "Stringer", new DateTime(2024, 1, 3, 14, 7, 49, 775, DateTimeKind.Local).AddTicks(157), 2, "www.google.com" },
                    { 2, "Inter", new DateTime(2024, 1, 3, 14, 7, 49, 775, DateTimeKind.Local).AddTicks(170), 3, "www.google.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicConsultations_SelectedLocationIndex",
                table: "ClinicConsultations",
                column: "SelectedLocationIndex");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicConsultations");
        }
    }
}
