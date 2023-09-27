using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_ProductionCompain_IdProduction",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesGenders_Genders_IdGender",
                table: "SeriesGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesGenders_Series_IdSerie",
                table: "SeriesGenders");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_ProductionCompain_IdProduction",
                table: "Series",
                column: "IdProduction",
                principalTable: "ProductionCompain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesGenders_Genders_IdGender",
                table: "SeriesGenders",
                column: "IdGender",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesGenders_Series_IdSerie",
                table: "SeriesGenders",
                column: "IdSerie",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_ProductionCompain_IdProduction",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesGenders_Genders_IdGender",
                table: "SeriesGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesGenders_Series_IdSerie",
                table: "SeriesGenders");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_ProductionCompain_IdProduction",
                table: "Series",
                column: "IdProduction",
                principalTable: "ProductionCompain",
                principalColumn: "Id");

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
    }
}
