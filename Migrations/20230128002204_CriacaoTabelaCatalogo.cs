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
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogo_Fornecedores_fornecedorCodigo",
                table: "Catalogo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogo",
                table: "Catalogo");

            migrationBuilder.RenameTable(
                name: "Catalogo",
                newName: "Catalogos");

            migrationBuilder.RenameIndex(
                name: "IX_Catalogo_fornecedorCodigo",
                table: "Catalogos",
                newName: "IX_Catalogos_fornecedorCodigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogos",
                table: "Catalogos",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogos_Fornecedores_fornecedorCodigo",
                table: "Catalogos",
                column: "fornecedorCodigo",
                principalTable: "Fornecedores",
                principalColumn: "Codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogos_Fornecedores_fornecedorCodigo",
                table: "Catalogos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogos",
                table: "Catalogos");

            migrationBuilder.RenameTable(
                name: "Catalogos",
                newName: "Catalogo");

            migrationBuilder.RenameIndex(
                name: "IX_Catalogos_fornecedorCodigo",
                table: "Catalogo",
                newName: "IX_Catalogo_fornecedorCodigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogo",
                table: "Catalogo",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogo_Fornecedores_fornecedorCodigo",
                table: "Catalogo",
                column: "fornecedorCodigo",
                principalTable: "Fornecedores",
                principalColumn: "Codigo");
        }
    }
}
