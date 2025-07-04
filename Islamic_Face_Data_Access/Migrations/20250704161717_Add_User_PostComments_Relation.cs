using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Islamic_Face_Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class Add_User_PostComments_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PostComments_userId",
                table: "PostComments",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Users_userId",
                table: "PostComments",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Users_userId",
                table: "PostComments");

            migrationBuilder.DropIndex(
                name: "IX_PostComments_userId",
                table: "PostComments");
        }
    }
}
