using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesProject.DataAccessLayer.Migrations
{
    public partial class addmigrationfifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HScores",
                table: "HScores");

            migrationBuilder.RenameTable(
                name: "HScores",
                newName: "HScoresShellGame");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HScoresShellGame",
                table: "HScoresShellGame",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HScoresShellGame",
                table: "HScoresShellGame");

            migrationBuilder.RenameTable(
                name: "HScoresShellGame",
                newName: "HScores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HScores",
                table: "HScores",
                column: "Id");
        }
    }
}
