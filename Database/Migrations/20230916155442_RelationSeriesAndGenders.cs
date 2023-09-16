using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class RelationSeriesAndGenders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Series",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "SeriesGenders",
                columns: table => new
                {
                    IdSerie = table.Column<int>(type: "int", nullable: false),
                    IdGender = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfEdit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesGenders", x => new { x.IdSerie, x.IdGender });
                    table.ForeignKey(
                        name: "FK_SeriesGenders_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesGenders_Series_IdGender",
                        column: x => x.IdGender,
                        principalTable: "Series",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeriesGenders_GenderId",
                table: "SeriesGenders",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesGenders_IdGender",
                table: "SeriesGenders",
                column: "IdGender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeriesGenders");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Series",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
