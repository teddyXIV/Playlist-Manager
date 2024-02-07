using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaylistManager.Migrations
{
    public partial class AddPlayToPlaylists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Plays",
                table: "Playlists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plays",
                table: "Playlists");
        }
    }
}
