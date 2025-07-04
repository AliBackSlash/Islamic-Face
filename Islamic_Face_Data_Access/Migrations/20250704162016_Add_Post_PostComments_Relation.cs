using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Islamic_Face_Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class Add_Post_PostComments_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PostComments_postId",
                table: "PostComments",
                column: "postId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Posts_postId",
                table: "PostComments",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Posts_postId",
                table: "PostComments");

            migrationBuilder.DropIndex(
                name: "IX_PostComments_postId",
                table: "PostComments");
        }
    }
}
