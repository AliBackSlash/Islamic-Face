using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Islamic_Face_Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class Add_Post_PostTags_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PostTags_postId",
                table: "PostTags",
                column: "postId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Posts_postId",
                table: "PostTags",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Posts_postId",
                table: "PostTags");

            migrationBuilder.DropIndex(
                name: "IX_PostTags_postId",
                table: "PostTags");
        }
    }
}
