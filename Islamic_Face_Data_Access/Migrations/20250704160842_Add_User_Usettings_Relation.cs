using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Islamic_Face_Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class Add_User_Usettings_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Id",
                table: "UserSettings",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt")
                ;

            migrationBuilder.AlterColumn<byte>(
                name: "settingId",
                table: "Users",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateIndex(
                name: "IX_Users_settingId",
                table: "Users",
                column: "settingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserSettings_settingId",
                table: "Users",
                column: "settingId",
                principalTable: "UserSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserSettings_settingId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_settingId",
                table: "Users");

            migrationBuilder.AlterColumn<byte>(
                name: "Id",
                table: "UserSettings",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<byte>(
                name: "settingId",
                table: "Users",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");
        }
    }
}
