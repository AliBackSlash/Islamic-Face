using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IslamicFace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionalTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterestFields",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "TINYINT", nullable: false),
                    FieldName_ENG = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    FieldName_ARB = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false, defaultValueSql: "NEWID()"),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    TriggeredByUserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Type = table.Column<byte>(type: "TINYINT", nullable: false),
                    PostId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    CommentId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    IsRead = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    NotificationURL = table.Column<string>(type: "VARCHAR(2083)", maxLength: 2083, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_TriggeredByUserId",
                        column: x => x.TriggeredByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBlocks",
                columns: table => new
                {
                    BlockerId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    BlockedId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    IsBlocked = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBlocks", x => new { x.BlockerId, x.BlockedId });
                    table.ForeignKey(
                        name: "FK_UserBlocks_Users_BlockedId",
                        column: x => x.BlockedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBlocks_Users_BlockerId",
                        column: x => x.BlockerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInterestFields",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    InterestFieldId = table.Column<byte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterestFields", x => new { x.UserId, x.InterestFieldId });
                    table.ForeignKey(
                        name: "FK_UserInterestFields_InterestFields_InterestFieldId",
                        column: x => x.InterestFieldId,
                        principalTable: "InterestFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInterestFields_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InterestFields",
                columns: new[] { "Id", "FieldName_ARB", "FieldName_ENG" },
                values: new object[,]
                {
                    { (byte)1, "العلوم", "Science" },
                    { (byte)2, "التكنولوجيا", "Technology" },
                    { (byte)3, "التعليم", "Education" },
                    { (byte)4, "الرياضة", "Sports" },
                    { (byte)5, "الزراعة", "Agriculture" },
                    { (byte)6, "الفنون", "Arts" },
                    { (byte)7, "الصحة", "Health" },
                    { (byte)8, "الأعمال", "Business" },
                    { (byte)9, "الدين", "Religion" },
                    { (byte)10, "السياسة", "Politics" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TriggeredByUserId",
                table: "Notifications",
                column: "TriggeredByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBlocks_BlockedId",
                table: "UserBlocks",
                column: "BlockedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterestFields_InterestFieldId",
                table: "UserInterestFields",
                column: "InterestFieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "UserBlocks");

            migrationBuilder.DropTable(
                name: "UserInterestFields");

            migrationBuilder.DropTable(
                name: "InterestFields");
        }
    }
}
