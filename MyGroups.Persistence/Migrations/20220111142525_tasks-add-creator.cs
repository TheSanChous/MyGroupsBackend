using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGroups.Persistence.Migrations
{
    public partial class tasksaddcreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Tasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatorId",
                table: "Tasks",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_CreatorId",
                table: "Tasks",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_CreatorId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CreatorId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Tasks");
        }
    }
}
