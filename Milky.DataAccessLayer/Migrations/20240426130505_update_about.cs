using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Milky.DataAccessLayer.Migrations
{
    public partial class update_about : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Services1Description",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Services2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Services2Description",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Services1Description",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Services2",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Services2Description",
                table: "Abouts");
        }
    }
}
