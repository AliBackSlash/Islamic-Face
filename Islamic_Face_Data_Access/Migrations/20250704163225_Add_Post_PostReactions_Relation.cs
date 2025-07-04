using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Islamic_Face_Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class Add_Post_PostReactions_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_postId",
                table: "PostReactions",
                column: "postId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReactions_Posts_postId",
                table: "PostReactions",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReactions_Posts_postId",
                table: "PostReactions");

            migrationBuilder.DropIndex(
                name: "IX_PostReactions_postId",
                table: "PostReactions");
        }
    }
}
