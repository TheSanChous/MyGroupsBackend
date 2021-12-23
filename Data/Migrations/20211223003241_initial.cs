using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoleUserInGroups",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("227cd08c-247f-4b7d-a9b6-d5451387e52f"), "Admin" },
                    { new Guid("a5ec79bc-40b8-467f-a24c-9eeeecbeaff5"), "Member" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleUserInGroups",
                keyColumn: "Id",
                keyValue: new Guid("227cd08c-247f-4b7d-a9b6-d5451387e52f"));

            migrationBuilder.DeleteData(
                table: "RoleUserInGroups",
                keyColumn: "Id",
                keyValue: new Guid("a5ec79bc-40b8-467f-a24c-9eeeecbeaff5"));
        }
    }
}
