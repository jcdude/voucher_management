using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTS.Persistence.Migrations
{
    public partial class PTS_12312018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExternalIdExpiry",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalIdExpiry",
                table: "Customers");
        }
    }
}
