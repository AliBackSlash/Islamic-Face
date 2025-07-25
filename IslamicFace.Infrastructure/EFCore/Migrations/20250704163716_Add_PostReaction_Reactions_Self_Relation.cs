using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslamicFace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_PostReaction_Reactions_Self_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "reactTypeID",
                table: "PostReactions",
                type: "TinyInt",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_reactTypeID",
                table: "PostReactions",
                column: "reactTypeID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReactions_Reactions_reactTypeID",
                table: "PostReactions",
                column: "reactTypeID",
                principalTable: "Reactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReactions_Reactions_reactTypeID",
                table: "PostReactions");

            migrationBuilder.DropIndex(
                name: "IX_PostReactions_reactTypeID",
                table: "PostReactions");

            migrationBuilder.AlterColumn<byte>(
                name: "reactTypeID",
                table: "PostReactions",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt");
        }
    }
}
