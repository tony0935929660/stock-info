using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddWeightedIndexAndOtcIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Taiex",
                table: "Summaries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaiexVolume",
                table: "Summaries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Tpex",
                table: "Summaries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TpexVolume",
                table: "Summaries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Taiex",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "TaiexVolume",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "Tpex",
                table: "Summaries");

            migrationBuilder.DropColumn(
                name: "TpexVolume",
                table: "Summaries");
        }
    }
}
