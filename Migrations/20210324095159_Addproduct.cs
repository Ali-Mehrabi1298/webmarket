using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppDJ.Migrations
{
    public partial class Addproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
