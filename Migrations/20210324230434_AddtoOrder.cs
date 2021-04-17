using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppDJ.Migrations
{
    public partial class AddtoOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_productId",
                table: "orders",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products_productId",
                table: "orders",
                column: "productId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_products_productId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_productId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "orders");
        }
    }
}
