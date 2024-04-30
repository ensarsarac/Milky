using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Milky.DataAccessLayer.Migrations
{
    public partial class add_teamsocialmedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamSocialMedia_Teams_TeamId",
                table: "TeamSocialMedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamSocialMedia",
                table: "TeamSocialMedia");

            migrationBuilder.RenameTable(
                name: "TeamSocialMedia",
                newName: "TeamSocialMedias");

            migrationBuilder.RenameIndex(
                name: "IX_TeamSocialMedia_TeamId",
                table: "TeamSocialMedias",
                newName: "IX_TeamSocialMedias_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamSocialMedias",
                table: "TeamSocialMedias",
                column: "TeamSocialMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamSocialMedias_Teams_TeamId",
                table: "TeamSocialMedias",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamSocialMedias_Teams_TeamId",
                table: "TeamSocialMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamSocialMedias",
                table: "TeamSocialMedias");

            migrationBuilder.RenameTable(
                name: "TeamSocialMedias",
                newName: "TeamSocialMedia");

            migrationBuilder.RenameIndex(
                name: "IX_TeamSocialMedias_TeamId",
                table: "TeamSocialMedia",
                newName: "IX_TeamSocialMedia_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamSocialMedia",
                table: "TeamSocialMedia",
                column: "TeamSocialMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamSocialMedia_Teams_TeamId",
                table: "TeamSocialMedia",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
