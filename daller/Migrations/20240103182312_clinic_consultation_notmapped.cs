using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace daller.Migrations
{
    /// <inheritdoc />
    public partial class clinic_consultation_notmapped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicConsultations_Locations_SelectedLocationIndex",
                table: "ClinicConsultations");

            migrationBuilder.DropIndex(
                name: "IX_ClinicConsultations_SelectedLocationIndex",
                table: "ClinicConsultations");

            migrationBuilder.UpdateData(
                table: "ClinicConsultations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 3, 15, 23, 12, 269, DateTimeKind.Local).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "ClinicConsultations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 3, 15, 23, 12, 269, DateTimeKind.Local).AddTicks(2080));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClinicConsultations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 3, 14, 7, 49, 775, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "ClinicConsultations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 3, 14, 7, 49, 775, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.CreateIndex(
                name: "IX_ClinicConsultations_SelectedLocationIndex",
                table: "ClinicConsultations",
                column: "SelectedLocationIndex");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicConsultations_Locations_SelectedLocationIndex",
                table: "ClinicConsultations",
                column: "SelectedLocationIndex",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
