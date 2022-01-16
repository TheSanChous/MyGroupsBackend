using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGroups.Persistence.Migrations
{
    public partial class complatedtaskupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "CompletedTask",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadedAt",
                table: "CompletedTask",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_CompletedTask_CreatorId",
                table: "CompletedTask",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTask_Users_CreatorId",
                table: "CompletedTask",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTask_Users_CreatorId",
                table: "CompletedTask");

            migrationBuilder.DropIndex(
                name: "IX_CompletedTask_CreatorId",
                table: "CompletedTask");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "CompletedTask");

            migrationBuilder.DropColumn(
                name: "UploadedAt",
                table: "CompletedTask");
        }
    }
}
