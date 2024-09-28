using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundRockWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ver2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterId",
                table: "Songs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterId",
                table: "Songs");
        }
    }
}
