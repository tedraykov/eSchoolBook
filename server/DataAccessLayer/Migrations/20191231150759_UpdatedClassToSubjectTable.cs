using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class UpdatedClassToSubjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ClassesToSubjects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "ClassesToSubjects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassesToSubjects_TeacherId",
                table: "ClassesToSubjects",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesToSubjects_SchoolUsers_TeacherId",
                table: "ClassesToSubjects",
                column: "TeacherId",
                principalTable: "SchoolUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassesToSubjects_SchoolUsers_TeacherId",
                table: "ClassesToSubjects");

            migrationBuilder.DropIndex(
                name: "IX_ClassesToSubjects_TeacherId",
                table: "ClassesToSubjects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClassesToSubjects");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "ClassesToSubjects");
        }
    }
}
