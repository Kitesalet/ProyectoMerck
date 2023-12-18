using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoMerck.Migrations
{
    /// <inheritdoc />
    public partial class fhjd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Locations",
                newName: "ProvinceLocationId");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvinceLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvinceLocations_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Brasil" },
                    { 2, "Argentina" },
                    { 3, "Chile" }
                });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProvinceLocationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProvinceLocationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProvinceLocationId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProvinceLocationId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProvinceLocationId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProvinceLocationId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProvinceLocationId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProvinceLocationId",
                value: 3);

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Buenos Aires" },
                    { 2, 2, "Buenos Aires-GBA" },
                    { 3, 2, "Capital Federal" },
                    { 4, 2, "Catamarca" },
                    { 5, 2, "Chaco" },
                    { 6, 2, "Chubut" },
                    { 7, 2, "Córdoba" },
                    { 8, 2, "Corrientes" },
                    { 9, 2, "Entre Ríos" },
                    { 10, 2, "Formosa" },
                    { 11, 2, "Jujuy" },
                    { 12, 2, "La Pampa" },
                    { 13, 2, "La Rioja" },
                    { 14, 2, "Mendoza" },
                    { 15, 2, "Misiones" },
                    { 16, 2, "Neuquén" },
                    { 17, 2, "Río Negro" },
                    { 18, 2, "Salta" },
                    { 19, 2, "San Juan" },
                    { 20, 2, "San Luis" },
                    { 21, 2, "Santa Cruz" },
                    { 22, 2, "Santa Fe" },
                    { 23, 2, "Santiago del Estero" },
                    { 24, 2, "Tierra del Fuego" },
                    { 25, 2, "Tucumán" }
                });

            migrationBuilder.InsertData(
                table: "ProvinceLocations",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "Playa del Sol", 1 },
                    { 2, "Montaña Encantada", 1 },
                    { 3, "Ciudad del Viento", 2 },
                    { 4, "Valle de las Flores", 2 },
                    { 5, "Centro Histórico", 3 },
                    { 6, "Barrio Moderno", 3 },
                    { 7, "Oasis del Desierto", 4 },
                    { 8, "Pico de la Luna", 4 },
                    { 9, "Selva Esmeralda", 5 },
                    { 10, "Río Dorado", 5 },
                    { 11, "Costa Azul", 6 },
                    { 12, "Bosque Mágico", 6 },
                    { 13, "Sierras Doradas", 7 },
                    { 14, "Valle de los Suspiros", 7 },
                    { 15, "Río Paraná", 8 },
                    { 16, "Bosque Encantado", 8 },
                    { 17, "Termas del Guaychú", 9 },
                    { 18, "Puerto de las Palmas", 9 },
                    { 19, "Lago Formosa", 10 },
                    { 20, "Pueblo de las Aves", 10 },
                    { 21, "Valle de los Colores", 11 },
                    { 22, "Cerro de Siete Colores", 11 },
                    { 23, "Pampa Dorada", 12 },
                    { 24, "Laguna Escondida", 12 },
                    { 25, "Valle de la Luna", 13 },
                    { 26, "Cascada del Cielo", 13 },
                    { 27, "Viñedos del Sol", 14 },
                    { 28, "Cerro Aconcagua", 14 },
                    { 29, "Cataratas del Iguazú", 15 },
                    { 30, "Bosque Misionero", 15 },
                    { 31, "Lago Nahuel Huapi", 16 },
                    { 32, "Cerro Chapelco", 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ProvinceLocationId",
                table: "Locations",
                column: "ProvinceLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvinceLocations_ProvinceId",
                table: "ProvinceLocations",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_ProvinceLocations_ProvinceLocationId",
                table: "Locations",
                column: "ProvinceLocationId",
                principalTable: "ProvinceLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_ProvinceLocations_ProvinceLocationId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "ProvinceLocations");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ProvinceLocationId",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "ProvinceLocationId",
                table: "Locations",
                newName: "LocationId");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "LocationId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "LocationId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "LocationId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "LocationId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "LocationId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "LocationId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "LocationId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "LocationId",
                value: 0);
        }
    }
}
