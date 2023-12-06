using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class post1111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
