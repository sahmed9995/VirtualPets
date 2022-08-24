using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualPets2.Server.Data.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diet",
                table: "UserAnimals");

            migrationBuilder.DropColumn(
                name: "Dwelling",
                table: "UserAnimals");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserAnimals");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserAnimals");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "UserAnimals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Diet",
                table: "UserAnimals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Dwelling",
                table: "UserAnimals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserAnimals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserAnimals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "UserAnimals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
