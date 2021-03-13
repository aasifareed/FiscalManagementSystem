using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FiscalManagementSystem.Migrations
{
    public partial class AddFileproperyinProductpicturetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "ProductPictures");

            migrationBuilder.AddColumn<byte[]>(
                name: "file",
                table: "ProductPictures",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file",
                table: "ProductPictures");

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "ProductPictures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
