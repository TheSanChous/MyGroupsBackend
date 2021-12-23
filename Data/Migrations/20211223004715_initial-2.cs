using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Groups_GroupId",
                table: "Publications");

            migrationBuilder.DeleteData(
                table: "RoleUserInGroups",
                keyColumn: "Id",
                keyValue: new Guid("227cd08c-247f-4b7d-a9b6-d5451387e52f"));

            migrationBuilder.DeleteData(
                table: "RoleUserInGroups",
                keyColumn: "Id",
                keyValue: new Guid("a5ec79bc-40b8-467f-a24c-9eeeecbeaff5"));

            migrationBuilder.InsertData(
                table: "RoleUserInGroups",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("f35e8dca-3bf5-4abf-9ba7-0d7b3860695a"), "Admin" },
                    { new Guid("f1cc6a2c-9c1d-498f-900e-26609ccd047a"), "Member" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Groups_GroupId",
                table: "Publications",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Groups_GroupId",
                table: "Publications");

            migrationBuilder.DeleteData(
                table: "RoleUserInGroups",
                keyColumn: "Id",
                keyValue: new Guid("f1cc6a2c-9c1d-498f-900e-26609ccd047a"));

            migrationBuilder.DeleteData(
                table: "RoleUserInGroups",
                keyColumn: "Id",
                keyValue: new Guid("f35e8dca-3bf5-4abf-9ba7-0d7b3860695a"));

            migrationBuilder.InsertData(
                table: "RoleUserInGroups",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("227cd08c-247f-4b7d-a9b6-d5451387e52f"), "Admin" },
                    { new Guid("a5ec79bc-40b8-467f-a24c-9eeeecbeaff5"), "Member" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Groups_GroupId",
                table: "Publications",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
