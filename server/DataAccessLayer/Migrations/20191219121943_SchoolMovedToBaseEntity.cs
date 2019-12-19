using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class SchoolMovedToBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolUsers_Schools_Student_SchoolId",
                table: "SchoolUsers");

            migrationBuilder.DropIndex(
                name: "IX_SchoolUsers_Student_SchoolId",
                table: "SchoolUsers");

            migrationBuilder.DropColumn(
                name: "Student_SchoolId",
                table: "SchoolUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Student_SchoolId",
                table: "SchoolUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolUsers_Student_SchoolId",
                table: "SchoolUsers",
                column: "Student_SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolUsers_Schools_Student_SchoolId",
                table: "SchoolUsers",
                column: "Student_SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
