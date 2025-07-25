using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslamicFace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_User_Country_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "countryID",
                table: "Users",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Users_countryID",
                table: "Users",
                column: "countryID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_countryID",
                table: "Users",
                column: "countryID",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_countryID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_countryID",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "countryID",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");
        }
    }
}
