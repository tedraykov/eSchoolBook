using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class MakeUserPinUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_SchoolUsers_Pin",
                table: "SchoolUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Pin",
                table: "SchoolUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolUsers_Pin",
                table: "SchoolUsers",
                column: "Pin",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SchoolUsers_Pin",
                table: "SchoolUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Pin",
                table: "SchoolUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_SchoolUsers_Pin",
                table: "SchoolUsers",
                column: "Pin");
        }
    }
}
