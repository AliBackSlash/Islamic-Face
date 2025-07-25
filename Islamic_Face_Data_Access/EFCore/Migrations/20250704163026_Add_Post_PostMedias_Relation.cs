using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslamicFace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Post_PostMedias_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PostMedias_postId",
                table: "PostMedias",
                column: "postId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostMedias_Posts_postId",
                table: "PostMedias",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostMedias_Posts_postId",
                table: "PostMedias");

            migrationBuilder.DropIndex(
                name: "IX_PostMedias_postId",
                table: "PostMedias");
        }
    }
}
