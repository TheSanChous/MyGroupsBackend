using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGroups.Persistence.Migrations
{
    public partial class gradetaskaddupdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTasks_Grades_GradeId",
                table: "CompletedTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Users_UserId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_UserId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_CompletedTasks_GradeId",
                table: "CompletedTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "CompletedTasks");

            migrationBuilder.CreateTable(
                name: "GradesTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GradeId = table.Column<Guid>(type: "uuid", nullable: true),
                    ComletedTaskId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradesTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradesTasks_CompletedTasks_ComletedTaskId",
                        column: x => x.ComletedTaskId,
                        principalTable: "CompletedTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GradesTasks_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradesTasks_ComletedTaskId",
                table: "GradesTasks",
                column: "ComletedTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_GradesTasks_GradeId",
                table: "GradesTasks",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_CompletedTasks_Id",
                table: "Grades",
                column: "Id",
                principalTable: "CompletedTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_CompletedTasks_Id",
                table: "Grades");

            migrationBuilder.DropTable(
                name: "GradesTasks");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Grades",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GradeId",
                table: "CompletedTasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_UserId",
                table: "Grades",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedTasks_GradeId",
                table: "CompletedTasks",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTasks_Grades_GradeId",
                table: "CompletedTasks",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Users_UserId",
                table: "Grades",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
