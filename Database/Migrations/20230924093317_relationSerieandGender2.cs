using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class relationSerieandGender2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeriesGenders_Genders_GenderId",
                table: "SeriesGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesGenders_Series_IdGender",
                table: "SeriesGenders");

            migrationBuilder.DropIndex(
                name: "IX_SeriesGenders_GenderId",
                table: "SeriesGenders");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "SeriesGenders");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesGenders_Genders_IdGender",
                table: "SeriesGenders",
                column: "IdGender",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesGenders_Series_IdSerie",
                table: "SeriesGenders",
                column: "IdSerie",
                principalTable: "Series",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeriesGenders_Genders_IdGender",
                table: "SeriesGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesGenders_Series_IdSerie",
                table: "SeriesGenders");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "SeriesGenders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SeriesGenders_GenderId",
                table: "SeriesGenders",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesGenders_Genders_GenderId",
                table: "SeriesGenders",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesGenders_Series_IdGender",
                table: "SeriesGenders",
                column: "IdGender",
                principalTable: "Series",
                principalColumn: "Id");
        }
    }
}
