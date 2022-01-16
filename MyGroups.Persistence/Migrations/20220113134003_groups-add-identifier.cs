using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGroups.Persistence.Migrations
{
    public partial class groupsaddidentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "Groups",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Identifier",
                table: "Groups",
                column: "Identifier",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Groups_Identifier",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Groups");
        }
    }
}
