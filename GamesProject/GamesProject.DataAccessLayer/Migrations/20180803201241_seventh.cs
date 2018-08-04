using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesProject.DataAccessLayer.Migrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Win",
                table: "HScoresShellGame",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Win",
                table: "HScoresShellGame");
        }
    }
}
