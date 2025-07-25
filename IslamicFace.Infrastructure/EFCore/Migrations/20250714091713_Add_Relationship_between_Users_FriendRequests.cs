using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslamicFace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Relationship_between_Users_FriendRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ReceiverID",
                table: "FriendRequests",
                column: "ReceiverID");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_ReceiverID",
                table: "FriendRequests",
                column: "ReceiverID",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_senderID",
                table: "FriendRequests",
                column: "senderID",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_ReceiverID",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_senderID",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_ReceiverID",
                table: "FriendRequests");
        }
    }
}
