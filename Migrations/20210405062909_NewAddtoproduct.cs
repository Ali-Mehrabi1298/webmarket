using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppDJ.Migrations
{
    public partial class NewAddtoproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "CategoryToproducts");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "CategoryToproducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
