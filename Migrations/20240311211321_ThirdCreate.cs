using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuneaPianoPSP.Migrations
{
    /// <inheritdoc />
    public partial class ThirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_artistId",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "artistId",
                table: "Songs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_artistId",
                table: "Songs",
                column: "artistId",
                principalTable: "Artists",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_artistId",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "artistId",
                table: "Songs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_artistId",
                table: "Songs",
                column: "artistId",
                principalTable: "Artists",
                principalColumn: "id");
        }
    }
}
