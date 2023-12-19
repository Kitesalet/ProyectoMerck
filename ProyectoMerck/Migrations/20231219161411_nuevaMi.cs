using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoMerck.Migrations
{
    /// <inheritdoc />
    public partial class nuevaMi : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultMotives");
        }
    }
}
