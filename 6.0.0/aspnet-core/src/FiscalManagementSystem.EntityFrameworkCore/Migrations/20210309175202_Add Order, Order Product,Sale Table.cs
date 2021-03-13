using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FiscalManagementSystem.Migrations
{
    public partial class AddOrderOrderProductSaleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "size",
                table: "Products");
        }
    }
}
