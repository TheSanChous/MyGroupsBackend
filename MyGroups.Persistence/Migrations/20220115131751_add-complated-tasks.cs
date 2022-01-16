using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGroups.Persistence.Migrations
{
    public partial class addcomplatedtasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTask_Files_FileId",
                table: "CompletedTask");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTask_Grades_GradeId",
                table: "CompletedTask");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTask_Tasks_TaskId",
                table: "CompletedTask");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTask_Users_CreatorId",
                table: "CompletedTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompletedTask",
                table: "CompletedTask");

            migrationBuilder.RenameTable(
                name: "CompletedTask",
                newName: "CompletedTasks");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedTask_TaskId",
                table: "CompletedTasks",
                newName: "IX_CompletedTasks_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedTask_GradeId",
                table: "CompletedTasks",
                newName: "IX_CompletedTasks_GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedTask_FileId",
                table: "CompletedTasks",
                newName: "IX_CompletedTasks_FileId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedTask_CreatorId",
                table: "CompletedTasks",
                newName: "IX_CompletedTasks_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompletedTasks",
                table: "CompletedTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTasks_Files_FileId",
                table: "CompletedTasks",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTasks_Grades_GradeId",
                table: "CompletedTasks",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTasks_Tasks_TaskId",
                table: "CompletedTasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTasks_Users_CreatorId",
                table: "CompletedTasks",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTasks_Files_FileId",
                table: "CompletedTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTasks_Grades_GradeId",
                table: "CompletedTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTasks_Tasks_TaskId",
                table: "CompletedTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTasks_Users_CreatorId",
                table: "CompletedTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompletedTasks",
                table: "CompletedTasks");

            migrationBuilder.RenameTable(
                name: "CompletedTasks",
                newName: "CompletedTask");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedTasks_TaskId",
                table: "CompletedTask",
                newName: "IX_CompletedTask_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedTasks_GradeId",
                table: "CompletedTask",
                newName: "IX_CompletedTask_GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedTasks_FileId",
                table: "CompletedTask",
                newName: "IX_CompletedTask_FileId");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedTasks_CreatorId",
                table: "CompletedTask",
                newName: "IX_CompletedTask_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompletedTask",
                table: "CompletedTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTask_Files_FileId",
                table: "CompletedTask",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTask_Grades_GradeId",
                table: "CompletedTask",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTask_Tasks_TaskId",
                table: "CompletedTask",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTask_Users_CreatorId",
                table: "CompletedTask",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
