using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuneaPianoPSP.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "length",
                table: "Songs",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "artistId",
                table: "Songs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "album",
                table: "Songs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "bio",
                table: "Artists",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "GenreSong",
                columns: table => new
                {
                    Genresid = table.Column<int>(type: "integer", nullable: false),
                    Songsid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSong", x => new { x.Genresid, x.Songsid });
                    table.ForeignKey(
                        name: "FK_GenreSong_Genres_Genresid",
                        column: x => x.Genresid,
                        principalTable: "Genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSong_Songs_Songsid",
                        column: x => x.Songsid,
                        principalTable: "Songs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_artistId",
                table: "Songs",
                column: "artistId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreSong_Songsid",
                table: "GenreSong",
                column: "Songsid");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_artistId",
                table: "Songs",
                column: "artistId",
                principalTable: "Artists",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_artistId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "GenreSong");

            migrationBuilder.DropIndex(
                name: "IX_Songs_artistId",
                table: "Songs");

            migrationBuilder.AlterColumn<decimal>(
                name: "length",
                table: "Songs",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "artistId",
                table: "Songs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "album",
                table: "Songs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "bio",
                table: "Artists",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
