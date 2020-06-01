using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotOn.Infrastructure.Migrations
{
    public partial class addtagtoaward : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_TagId",
                table: "Events",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Tags_TagId",
                table: "Events",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Tags_TagId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_TagId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Events");
        }
    }
}
