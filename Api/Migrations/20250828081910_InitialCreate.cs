using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Summaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForeignInvestor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvestmentTrust = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DealerSelf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarginBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsdExchange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sp500 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nasdaq = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dji = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sox = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsGovernmentBound = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summaries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Summaries");
        }
    }
}
