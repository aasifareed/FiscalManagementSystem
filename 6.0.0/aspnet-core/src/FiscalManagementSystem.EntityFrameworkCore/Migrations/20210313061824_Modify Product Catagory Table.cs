using Microsoft.EntityFrameworkCore.Migrations;

namespace FiscalManagementSystem.Migrations
{
    public partial class ModifyProductCatagoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tax",
                table: "ProductCatagory",
                newName: "CatagoryNumber");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProductCatagory",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProductCatagory");

            migrationBuilder.RenameColumn(
                name: "CatagoryNumber",
                table: "ProductCatagory",
                newName: "Tax");
        }
    }
}
