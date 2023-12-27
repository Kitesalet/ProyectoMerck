using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoMerck.Migrations
{
    /// <inheritdoc />
    public partial class seeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Latitude", "Longitude", "Subtitle", "Title" },
                values: new object[,]
                {
                    { 1, -34.600677504040895, -58.387263729958455, "Centro Fertilidad", "CEGYR" },
                    { 2, -34.580702852634481, -58.430260973627661, "Centro Fertilidad", "CER" },
                    { 3, -34.578846588221204, -58.460103931977983, "Centro Fertilidad", "CIMER" },
                    { 4, -34.599254733727243, -58.401810339490027, "Centro Fertilidad", "CRECER" },
                    { 5, -34.597439056459208, -58.397189279473473, "Centro Fertilidad", "HIALITUS" },
                    { 6, -34.606202223417398, -58.425645264604945, "Centro Fertilidad", "HOSPITAL ITALIANO" },
                    { 7, -34.596689236707874, -58.399734815343471, "Centro Fertilidad", "IFER" },
                    { 8, -34.557128982074609, -58.447618128835863, "Centro Fertilidad", "WEFIV" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
