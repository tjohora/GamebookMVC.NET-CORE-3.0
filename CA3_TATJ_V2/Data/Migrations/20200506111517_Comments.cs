using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CA3_TATJ_V2.Data.Migrations
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "commentID",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    commentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commentDate = table.Column<DateTime>(nullable: false),
                    content = table.Column<string>(nullable: true),
                    postId = table.Column<int>(nullable: false),
                    userName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.commentID);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Posts_commentID",
            //    table: "Posts",
            //    column: "commentID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Posts_Comments_commentID",
            //    table: "Posts",
            //    column: "commentID",
            //    principalTable: "Comments",
            //    principalColumn: "commentID",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Comments_commentID",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Posts_commentID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "commentID",
                table: "Posts");
        }
    }
}
