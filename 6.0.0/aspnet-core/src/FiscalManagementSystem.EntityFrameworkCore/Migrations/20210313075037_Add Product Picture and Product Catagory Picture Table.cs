using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FiscalManagementSystem.Migrations
{
    public partial class AddProductPictureandProductCatagoryPictureTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "ProductCatagoryPictures");

            migrationBuilder.RenameColumn(
                name: "TagName",
                table: "ProductPictures",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TagName",
                table: "ProductCatagoryPictures",
                newName: "Name");

            migrationBuilder.AddColumn<byte[]>(
                name: "file",
                table: "ProductCatagoryPictures",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file",
                table: "ProductCatagoryPictures");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductPictures",
                newName: "TagName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductCatagoryPictures",
                newName: "TagName");

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "ProductCatagoryPictures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
