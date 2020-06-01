using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotOn.Infrastructure.Migrations
{
    public partial class PriceToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Publications",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Publications",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
