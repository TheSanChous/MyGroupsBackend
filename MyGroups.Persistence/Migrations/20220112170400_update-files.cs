using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGroups.Persistence.Migrations
{
    public partial class updatefiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Files");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Files",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Files");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Files",
                type: "bytea",
                nullable: true);
        }
    }
}
