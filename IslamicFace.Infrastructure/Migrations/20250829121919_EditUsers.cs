using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslamicFace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "gender",
                table: "Users",
                type: "Bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "Bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "gender",
                table: "Users",
                type: "Bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "Bit",
                oldDefaultValue: true);
        }
    }
}
