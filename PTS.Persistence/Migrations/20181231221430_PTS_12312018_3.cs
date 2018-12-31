using Microsoft.EntityFrameworkCore.Migrations;

namespace PTS.Persistence.Migrations
{
    public partial class PTS_12312018_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Services",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_CustomerId",
                table: "Services",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Customers_CustomerId",
                table: "Services",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Customers_CustomerId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_CustomerId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Services");
        }
    }
}
