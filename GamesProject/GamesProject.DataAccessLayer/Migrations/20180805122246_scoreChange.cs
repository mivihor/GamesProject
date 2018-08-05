using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesProject.DataAccessLayer.Migrations
{
    public partial class scoreChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "HScoresShellGame",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "HScoresShellGame",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
