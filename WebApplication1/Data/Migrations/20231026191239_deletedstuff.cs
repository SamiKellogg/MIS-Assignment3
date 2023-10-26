using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    public partial class deletedstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "poster",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "photo",
                table: "actors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "poster",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "photo",
                table: "actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
