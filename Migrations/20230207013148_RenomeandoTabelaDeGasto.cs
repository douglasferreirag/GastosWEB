using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gastos.Migrations
{
    /// <inheritdoc />
    public partial class RenomeandoTabelaDeGasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gastos");

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    CodigoPessoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Desconto = table.Column<double>(type: "float", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pessoaCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Despesas_Pessoas_pessoaCodigo",
                        column: x => x.pessoaCodigo,
                        principalTable: "Pessoas",
                        principalColumn: "Codigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_pessoaCodigo",
                table: "Despesas",
                column: "pessoaCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.CreateTable(
                name: "Gastos",
                columns: table => new
                {
                    CodigoPessoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    pessoaCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Desconto = table.Column<double>(type: "float", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Gastos_Pessoas_pessoaCodigo",
                        column: x => x.pessoaCodigo,
                        principalTable: "Pessoas",
                        principalColumn: "Codigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_pessoaCodigo",
                table: "Gastos",
                column: "pessoaCodigo");
        }
    }
}
