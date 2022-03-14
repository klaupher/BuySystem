using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitacaoCompra",
                table: "SolicitacaoCompra");

            migrationBuilder.RenameTable(
                name: "SolicitacaoCompra",
                newName: "Compra");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalGeral",
                table: "Compra",
                type: "decimal(5, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compra",
                table: "Compra",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Compra_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId",
                principalTable: "Compra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Compra_SolicitacaoCompraId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compra",
                table: "Compra");

            migrationBuilder.RenameTable(
                name: "Compra",
                newName: "SolicitacaoCompra");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalGeral",
                table: "SolicitacaoCompra",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 2)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitacaoCompra",
                table: "SolicitacaoCompra",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId",
                principalTable: "SolicitacaoCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
