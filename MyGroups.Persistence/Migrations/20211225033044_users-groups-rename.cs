using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGroups.Persistence.Migrations
{
    public partial class usersgroupsrename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Groups_GroupId",
                table: "UserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Users_UserId",
                table: "UserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup");

            migrationBuilder.RenameTable(
                name: "UserGroup",
                newName: "UsersGroups");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroup_UserId",
                table: "UsersGroups",
                newName: "IX_UsersGroups_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroup_GroupId",
                table: "UsersGroups",
                newName: "IX_UsersGroups_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersGroups",
                table: "UsersGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGroups_Groups_GroupId",
                table: "UsersGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGroups_Users_UserId",
                table: "UsersGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersGroups_Groups_GroupId",
                table: "UsersGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersGroups_Users_UserId",
                table: "UsersGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersGroups",
                table: "UsersGroups");

            migrationBuilder.RenameTable(
                name: "UsersGroups",
                newName: "UserGroup");

            migrationBuilder.RenameIndex(
                name: "IX_UsersGroups_UserId",
                table: "UserGroup",
                newName: "IX_UserGroup_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersGroups_GroupId",
                table: "UserGroup",
                newName: "IX_UserGroup_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Groups_GroupId",
                table: "UserGroup",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Users_UserId",
                table: "UserGroup",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
