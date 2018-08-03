using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesProject.DataAccessLayer.Migrations
{
    public partial class sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserLogin",
                table: "HScoresShellGame",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserLogin",
                table: "HScoresShellGame",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
