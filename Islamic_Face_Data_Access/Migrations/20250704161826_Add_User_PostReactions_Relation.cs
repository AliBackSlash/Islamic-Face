using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Islamic_Face_Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class Add_User_PostReactions_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_PostReactions_Users_userId",
                table: "PostReactions",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReactions_Users_userId",
                table: "PostReactions");
        }
    }
}
