using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppDJ.Migrations
{
    public partial class ChangeOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "orders",
                newName: "dateTime");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "orders",
                newName: "DateTime");
        }
    }
}
