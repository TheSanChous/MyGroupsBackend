using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("98ea4bed-90aa-46f0-9ad2-67ab6bc36a88"), "Admin" },
                    { new Guid("262b5367-341b-4813-a29a-68aa3150477c"), "Member" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Groups_GroupId",
                table: "Publications",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Groups_GroupId",
                table: "Publications");

            migrationBuilder.DeleteData(
                table: "RoleUserInGroups",
                keyColumn: "Id",
                keyValue: new Guid("262b5367-341b-4813-a29a-68aa3150477c"));

            migrationBuilder.DeleteData(
                table: "RoleUserInGroups",
                keyColumn: "Id",
                keyValue: new Guid("98ea4bed-90aa-46f0-9ad2-67ab6bc36a88"));

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
    }
}
