using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TuneaPianoPSP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    bio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SongGenres",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    songId = table.Column<int>(type: "integer", nullable: false),
                    genreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongGenres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    artistId = table.Column<int>(type: "integer", nullable: false),
                    album = table.Column<string>(type: "text", nullable: false),
                    length = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "id", "age", "bio", "name" },
                values: new object[,]
                {
                    { 1, 26, "Big & Rich is an American country music duo composed of Big Kenny and John Rich, both of whom are songwriters, vocalists, and guitarists.", "Big and Rich" },
                    { 2, 55, "Having spent last spring and early summer with his taking-it-to-the-roots I Go Back 2023 Tour of those arenas and markets where he rose to major headlining status, the only country artist to be on Billboard’s Top 10 Touring Artists of the Last 25 Years for the past 14 years is bringing old friends and new to 18 full-scale stadiums with a few more major surprises to come.", "Kenny Chesney" },
                    { 3, 34, "On December 3, 1990, Enigma released its debut album “MCMXC a.D.”. It was the beginning of an exceptional global success story. A quarter-century later Enigma is launching “Enigma Moments” - an online event to commemorate the project’s 25th anniversary together with you, loyal Enigma fans.", "Enigma" },
                    { 4, 77, "Benjamin David Goodman (May 30, 1909 – June 13, 1986) was an American clarinetist and bandleader known as the \"King of Swing\".", "Benny Goodman" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "description" },
                values: new object[,]
                {
                    { 1, "Country" },
                    { 2, "Pop" },
                    { 3, "Jazz" },
                    { 4, "Blues" },
                    { 5, "R & B Soul" }
                });

            migrationBuilder.InsertData(
                table: "SongGenres",
                columns: new[] { "id", "genreId", "songId" },
                values: new object[,]
                {
                    { 1, 0, 0 },
                    { 2, 0, 1 },
                    { 3, 1, 2 },
                    { 4, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "id", "album", "artistId", "length", "title" },
                values: new object[,]
                {
                    { 1, "Horse of a Different Color", 0, 180m, "Save a Horse (Ride a Cowboy)" },
                    { 2, "No Shoes nation", 1, 183m, "Take Her Home" },
                    { 3, "The Fall of a Rebel Angel", 2, 339m, "The Omego Point" },
                    { 4, "The Essential Benny Goodman(Remastered)", 3, 540m, "Sing, Sing, Sing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "SongGenres");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
