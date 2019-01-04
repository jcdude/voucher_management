using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTS.Persistence.Migrations
{
    public partial class PTS_12312018_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExternalId",
                table: "Suppliers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ExternalId",
                table: "Categories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SupplierId",
                table: "Categories",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Suppliers_SupplierId",
                table: "Categories",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Suppliers_SupplierId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SupplierId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Categories");
        }
    }
}
