using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gastos.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaGasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gasto_Pessoas_pessoaCodigo",
                table: "Gasto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gasto",
                table: "Gasto");

            migrationBuilder.RenameTable(
                name: "Gasto",
                newName: "Gastos");

            migrationBuilder.RenameIndex(
                name: "IX_Gasto_pessoaCodigo",
                table: "Gastos",
                newName: "IX_Gastos_pessoaCodigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gastos",
                table: "Gastos",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_Pessoas_pessoaCodigo",
                table: "Gastos",
                column: "pessoaCodigo",
                principalTable: "Pessoas",
                principalColumn: "Codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_Pessoas_pessoaCodigo",
                table: "Gastos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gastos",
                table: "Gastos");

            migrationBuilder.RenameTable(
                name: "Gastos",
                newName: "Gasto");

            migrationBuilder.RenameIndex(
                name: "IX_Gastos_pessoaCodigo",
                table: "Gasto",
                newName: "IX_Gasto_pessoaCodigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gasto",
                table: "Gasto",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Gasto_Pessoas_pessoaCodigo",
                table: "Gasto",
                column: "pessoaCodigo",
                principalTable: "Pessoas",
                principalColumn: "Codigo");
        }
    }
}
