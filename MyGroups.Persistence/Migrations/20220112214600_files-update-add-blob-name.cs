using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGroups.Persistence.Migrations
{
    public partial class filesupdateaddblobname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlobName",
                table: "Files",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlobName",
                table: "Files");
        }
    }
}
