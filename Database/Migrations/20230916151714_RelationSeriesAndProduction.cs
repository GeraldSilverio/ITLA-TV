using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class RelationSeriesAndProduction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProduction",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Series_IdProduction",
                table: "Series",
                column: "IdProduction");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_ProductionCompain_IdProduction",
                table: "Series",
                column: "IdProduction",
                principalTable: "ProductionCompain",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_ProductionCompain_IdProduction",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Series_IdProduction",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "IdProduction",
                table: "Series");
        }
    }
}
