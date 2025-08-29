using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslamicFace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditOnUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "gender",
                table: "Users",
                type: "Bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "Bit");

            migrationBuilder.AddColumn<string>(
                name: "profileCoverURL",
                table: "Users",
                type: "VARCHAR(2083)",
                maxLength: 2083,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profileCoverURL",
                table: "Users");

            migrationBuilder.AlterColumn<bool>(
                name: "gender",
                table: "Users",
                type: "Bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "Bit",
                oldNullable: true);
        }
    }
}
