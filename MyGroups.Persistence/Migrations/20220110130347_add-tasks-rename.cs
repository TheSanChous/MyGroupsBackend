using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGroups.Persistence.Migrations
{
    public partial class addtasksrename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTask_File_FileId",
                table: "CompletedTask");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTask_Grade_GradeId",
                table: "CompletedTask");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTask_Task_TaskId",
                table: "CompletedTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Users_EvaluatorId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Users_UserId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_File_FileId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Groups_GroupId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grade",
                table: "Grade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_File",
                table: "File");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "Grade",
                newName: "Grades");

            migrationBuilder.RenameTable(
                name: "File",
                newName: "Files");

            migrationBuilder.RenameIndex(
                name: "IX_Task_GroupId",
                table: "Tasks",
                newName: "IX_Tasks_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_FileId",
                table: "Tasks",
                newName: "IX_Tasks_FileId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_UserId",
                table: "Grades",
                newName: "IX_Grades_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_EvaluatorId",
                table: "Grades",
                newName: "IX_Grades_EvaluatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
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
                name: "FK_Grades_Users_EvaluatorId",
                table: "Grades",
                column: "EvaluatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Users_UserId",
                table: "Grades",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Files_FileId",
                table: "Tasks",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Groups_GroupId",
                table: "Tasks",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_Grades_Users_EvaluatorId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Users_UserId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Files_FileId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Groups_GroupId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameTable(
                name: "Grades",
                newName: "Grade");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "File");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_GroupId",
                table: "Task",
                newName: "IX_Task_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_FileId",
                table: "Task",
                newName: "IX_Task_FileId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_UserId",
                table: "Grade",
                newName: "IX_Grade_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_EvaluatorId",
                table: "Grade",
                newName: "IX_Grade_EvaluatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grade",
                table: "Grade",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_File",
                table: "File",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTask_File_FileId",
                table: "CompletedTask",
                column: "FileId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTask_Grade_GradeId",
                table: "CompletedTask",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTask_Task_TaskId",
                table: "CompletedTask",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Users_EvaluatorId",
                table: "Grade",
                column: "EvaluatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Users_UserId",
                table: "Grade",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_File_FileId",
                table: "Task",
                column: "FileId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Groups_GroupId",
                table: "Task",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
