using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gastos.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    CodigoDespesa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoCatalogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    despesaCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    catalogoCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantidade = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Itens_Catalogos_catalogoCodigo",
                        column: x => x.catalogoCodigo,
                        principalTable: "Catalogos",
                        principalColumn: "Codigo");
                    table.ForeignKey(
                        name: "FK_Itens_Despesas_despesaCodigo",
                        column: x => x.despesaCodigo,
                        principalTable: "Despesas",
                        principalColumn: "Codigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Itens_catalogoCodigo",
                table: "Itens",
                column: "catalogoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_despesaCodigo",
                table: "Itens",
                column: "despesaCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Itens");
        }
    }
}
