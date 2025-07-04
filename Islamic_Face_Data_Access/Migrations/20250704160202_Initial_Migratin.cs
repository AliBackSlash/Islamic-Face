using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Islamic_Face_Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migratin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "TinyInt", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false),
                    senderID = table.Column<long>(type: "BigInt", nullable: false),
                    ReceiverID = table.Column<long>(type: "BigInt", nullable: false),
                    RequestStatus = table.Column<byte>(type: "TinyInt", nullable: false),
                    ResponseAt = table.Column<DateTime>(type: "DateTime", nullable: true),
                    DateSend = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<long>(type: "BigInt", nullable: false),
                    postId = table.Column<long>(type: "BigInt", nullable: false),
                    ParentCommentID = table.Column<long>(type: "BigInt", nullable: true),
                    Comment = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    reactLikeCount = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostMedias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    postId = table.Column<long>(type: "BigInt", nullable: false),
                    mediaType = table.Column<byte>(type: "tinyInt", nullable: false),
                    mediaURL = table.Column<string>(type: "VARCHAR(2083)", maxLength: 2083, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostReactions",
                columns: table => new
                {
                    userId = table.Column<long>(type: "BigInt", nullable: false),
                    postId = table.Column<long>(type: "BigInt", nullable: false),
                    reactTypeID = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReactions", x => new { x.userId, x.postId });
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false),
                    postText = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    userId = table.Column<long>(type: "BigInt", nullable: false),
                    createdAt = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    postId = table.Column<long>(type: "BigInt", nullable: false),
                    tag = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "TinyInt", nullable: false),
                    ReactType = table.Column<string>(type: "nvarchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(254)", maxLength: 254, nullable: false),
                    password = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    userName = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: false),
                    countryID = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    dateOfBirth = table.Column<DateOnly>(type: "Date", nullable: false),
                    joinDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GETDATE()"),
                    gender = table.Column<bool>(type: "Bit", nullable: false),
                    profilePictureURL = table.Column<string>(type: "VARCHAR(2083)", maxLength: 2083, nullable: false),
                    bio = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false),
                    userType = table.Column<byte>(type: "TinyInt", nullable: false),
                    settingId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "TinyInt", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderOfFriends = table.Column<string>(type: "nvarchar(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_senderID_ReceiverID",
                table: "FriendRequests",
                columns: new[] { "senderID", "ReceiverID" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "PostMedias");

            migrationBuilder.DropTable(
                name: "PostReactions");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserSettings");
        }
    }
}
