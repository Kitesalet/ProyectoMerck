using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace daller.Migrations
{
    /// <inheritdoc />
    public partial class dfkhdkfjdsh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultMotives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultMotiveX = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultMotives", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_ProvinceLocations_ProvinceLocationId",
                        column: x => x.ProvinceLocationId,
                        principalTable: "ProvinceLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConsultMotives",
                columns: new[] { "Id", "ConsultMotiveX" },
                values: new object[,]
                {
                    { 1, "Deseo de ser madre" },
                    { 2, "Problemas de fertilidad" },
                    { 3, "Planificación familiar" },
                    { 4, "Tratamientos de reproducción asistida" },
                    { 5, "Superar dificultades en la concepción" },
                    { 6, "Consultas preconcepcionales" },
                    { 7, "Evaluación de la salud reproductiva" },
                    { 8, "Seguimiento durante el embarazo" },
                    { 9, "Asesoramiento en técnicas de reproducción" },
                    { 10, "Preservación de la fertilidad" }
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

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Latitude", "Longitude", "ProvinceLocationId", "Subtitle", "Title" },
                values: new object[,]
                {
                    { 1, -34.600677504040895, -58.387263729958455, 1, "Centro Fertilidad", "CEGYR" },
                    { 2, -34.580702852634481, -58.430260973627661, 2, "Centro Fertilidad", "CER" },
                    { 3, -34.578846588221204, -58.460103931977983, 3, "Centro Fertilidad", "CIMER" },
                    { 4, -34.599254733727243, -58.401810339490027, 4, "Centro Fertilidad", "CRECER" },
                    { 5, -34.597439056459208, -58.397189279473473, 5, "Centro Fertilidad", "HIALITUS" },
                    { 6, -34.606202223417398, -58.425645264604945, 5, "Centro Fertilidad", "HOSPITAL ITALIANO" },
                    { 7, -34.596689236707874, -58.399734815343471, 4, "Centro Fertilidad", "IFER" },
                    { 8, -34.557128982074609, -58.447618128835863, 3, "Centro Fertilidad", "WEFIV" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultMotives");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ProvinceLocations");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
