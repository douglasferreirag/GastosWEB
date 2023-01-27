using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gastos.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaCatalogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogo",
                columns: table => new
                {
                    CodigoFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorUnitario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fornecedorCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogo", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Catalogo_Fornecedores_fornecedorCodigo",
                        column: x => x.fornecedorCodigo,
                        principalTable: "Fornecedores",
                        principalColumn: "Codigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogo_fornecedorCodigo",
                table: "Catalogo",
                column: "fornecedorCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalogo");
        }
    }
}
