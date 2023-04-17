using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PontosVida = table.Column<int>(type: "int", nullable: false),
                    Forca = table.Column<int>(type: "int", nullable: false),
                    Defesa = table.Column<int>(type: "int", nullable: false),
                    Inteligencia = table.Column<int>(type: "int", nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Personagens",
                columns: new[] { "Id", "Classe", "Defesa", "Forca", "Inteligencia", "Nome", "PontosVida" },
                values: new object[,]
                {
                    { 1, 1, 23, 17, 33, "Alice", 100 },
                    { 2, 1, 25, 15, 30, "Chapeleiro", 100 },
                    { 3, 3, 21, 18, 35, "Coelho Branco", 100 },
                    { 4, 2, 18, 18, 37, "Rainha de Copas", 100 },
                    { 5, 1, 17, 20, 31, "Rainha Branca", 100 },
                    { 6, 3, 13, 21, 34, "Cheshire", 100 },
                    { 7, 2, 11, 17, 35, "Valete de Copas", 100 }
                    { 8, 2, 11, 25, 35, "Absolem", 100}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personagens");
        }
    }
}
