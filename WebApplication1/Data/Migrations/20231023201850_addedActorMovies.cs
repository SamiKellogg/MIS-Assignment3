using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    public partial class addedActorMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActorID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MovieID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => x.id);
                    table.ForeignKey(
                        name: "FK_ActorMovie_actors_ActorID",
                        column: x => x.ActorID,
                        principalTable: "actors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActorMovie_actors_MovieID",
                        column: x => x.MovieID,
                        principalTable: "actors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_ActorID",
                table: "ActorMovie",
                column: "ActorID");

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_MovieID",
                table: "ActorMovie",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");
        }
    }
}
