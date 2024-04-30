using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Milky.DataAccessLayer.Migrations
{
    public partial class update_team_socialmedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TwitterUrl",
                table: "Teams");

            migrationBuilder.CreateTable(
                name: "TeamSocialMedia",
                columns: table => new
                {
                    TeamSocialMediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSocialMedia", x => x.TeamSocialMediaId);
                    table.ForeignKey(
                        name: "FK_TeamSocialMedia_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamSocialMedia_TeamId",
                table: "TeamSocialMedia",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamSocialMedia");

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TwitterUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
