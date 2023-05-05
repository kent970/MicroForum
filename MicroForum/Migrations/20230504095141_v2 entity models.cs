using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroForum.Migrations
{
    public partial class v2entitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Forum_ForumId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Forum",
                table: "Forum");

            migrationBuilder.RenameTable(
                name: "Forum",
                newName: "Forums");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forums",
                table: "Forums",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Forums_ForumId",
                table: "Posts",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Forums_ForumId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Forums",
                table: "Forums");

            migrationBuilder.RenameTable(
                name: "Forums",
                newName: "Forum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forum",
                table: "Forum",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Forum_ForumId",
                table: "Posts",
                column: "ForumId",
                principalTable: "Forum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
