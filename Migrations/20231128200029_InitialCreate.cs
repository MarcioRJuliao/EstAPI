using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EstAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ITENS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qtd = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ITENS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_ITENS",
                columns: new[] { "Id", "Categoria", "Nome", "Qtd" },
                values: new object[,]
                {
                    { 1, 2, "Lapis", 5 },
                    { 2, 3, "Sabao", 4 },
                    { 3, 1, "Carne", 7 },
                    { 4, 2, "Caneta", 15 },
                    { 5, 3, "Agua Sanitaria", 2 },
                    { 6, 1, "Saco de Arroz", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ITENS");
        }
    }
}
