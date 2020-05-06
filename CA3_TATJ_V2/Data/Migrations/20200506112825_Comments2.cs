using Microsoft.EntityFrameworkCore.Migrations;

namespace CA3_TATJ_V2.Data.Migrations
{
    public partial class Comments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Comments_commentID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_commentID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "commentID",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "commentID",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_commentID",
                table: "Posts",
                column: "commentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Comments_commentID",
                table: "Posts",
                column: "commentID",
                principalTable: "Comments",
                principalColumn: "commentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
