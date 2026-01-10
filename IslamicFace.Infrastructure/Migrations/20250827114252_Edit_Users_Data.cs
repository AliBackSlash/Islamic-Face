using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslamicFace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Users_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "bio",
                table: "Users",
                type: "NVARCHAR(160)",
                maxLength: 160,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(160)",
                oldMaxLength: 160,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fName",
                table: "Users",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lName",
                table: "Users",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lName",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "bio",
                table: "Users",
                type: "VARCHAR(160)",
                maxLength: 160,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(160)",
                oldMaxLength: 160,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Users",
                type: "VARCHAR(40)",
                maxLength: 40,
                nullable: true);
        }
    }
}
