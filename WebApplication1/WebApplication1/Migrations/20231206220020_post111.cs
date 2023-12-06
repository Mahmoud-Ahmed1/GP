using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class post111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "postId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "postId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "postId2",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    postid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_posts_postid",
                        column: x => x.postid,
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_postId",
                table: "AspNetUsers",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_postId1",
                table: "AspNetUsers",
                column: "postId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_postId2",
                table: "AspNetUsers",
                column: "postId2");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_postid",
                table: "Comment",
                column: "postid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_posts_postId",
                table: "AspNetUsers",
                column: "postId",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_posts_postId1",
                table: "AspNetUsers",
                column: "postId1",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_posts_postId2",
                table: "AspNetUsers",
                column: "postId2",
                principalTable: "posts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_posts_postId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_posts_postId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_posts_postId2",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_postId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_postId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_postId2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "postId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "postId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "postId2",
                table: "AspNetUsers");
        }
    }
}
