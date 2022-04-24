using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeratoShop.Migrations
{
    public partial class addreturnedproductdbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnedProduct_Orders_OrderId",
                table: "ReturnedProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReturnedProduct",
                table: "ReturnedProduct");

            migrationBuilder.RenameTable(
                name: "ReturnedProduct",
                newName: "ReturnedProducts");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnedProduct_OrderId",
                table: "ReturnedProducts",
                newName: "IX_ReturnedProducts_OrderId");

            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Revenue",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReturnedProducts",
                table: "ReturnedProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnedProducts_Orders_OrderId",
                table: "ReturnedProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnedProducts_Orders_OrderId",
                table: "ReturnedProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReturnedProducts",
                table: "ReturnedProducts");

            migrationBuilder.RenameTable(
                name: "ReturnedProducts",
                newName: "ReturnedProduct");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnedProducts_OrderId",
                table: "ReturnedProduct",
                newName: "IX_ReturnedProduct_OrderId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Revenue",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReturnedProduct",
                table: "ReturnedProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnedProduct_Orders_OrderId",
                table: "ReturnedProduct",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
