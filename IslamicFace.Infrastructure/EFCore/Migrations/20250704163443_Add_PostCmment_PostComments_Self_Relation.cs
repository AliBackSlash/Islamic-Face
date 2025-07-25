using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslamicFace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_PostCmment_PostComments_Self_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PostComments_ParentCommentID",
                table: "PostComments",
                column: "ParentCommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_PostComments_ParentCommentID",
                table: "PostComments",
                column: "ParentCommentID",
                principalTable: "PostComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_PostComments_ParentCommentID",
                table: "PostComments");

            migrationBuilder.DropIndex(
                name: "IX_PostComments_ParentCommentID",
                table: "PostComments");
        }
    }
}
