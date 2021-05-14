using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppDJ.Migrations
{
    public partial class Adddddddddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "RegisterViewModel");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "RegisterViewModel");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "AspNetUsers",
                newName: "codeconfig");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "RegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "RegisterViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "RegisterViewModel");

            migrationBuilder.DropColumn(
                name: "code",
                table: "RegisterViewModel");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "codeconfig",
                table: "AspNetUsers",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "RegisterViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "RegisterViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
