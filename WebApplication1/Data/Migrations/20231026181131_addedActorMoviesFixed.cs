using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    public partial class addedActorMoviesFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_actors_MovieID",
                table: "ActorMovie");

            migrationBuilder.AddColumn<byte[]>(
                name: "MovieImage",
                table: "Movie",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ActorImage",
                table: "actors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movie_MovieID",
                table: "ActorMovie",
                column: "MovieID",
                principalTable: "Movie",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movie_MovieID",
                table: "ActorMovie");

            migrationBuilder.DropColumn(
                name: "MovieImage",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ActorImage",
                table: "actors");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_actors_MovieID",
                table: "ActorMovie",
                column: "MovieID",
                principalTable: "actors",
                principalColumn: "Id");
        }
    }
}
