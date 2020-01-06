using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class UpdatedAbsencesAndStudentToGradeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "StudentsToGrades",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Absences",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsToGrades_TeacherId",
                table: "StudentsToGrades",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_TeacherId",
                table: "Absences",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_SchoolUsers_TeacherId",
                table: "Absences",
                column: "TeacherId",
                principalTable: "SchoolUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsToGrades_SchoolUsers_TeacherId",
                table: "StudentsToGrades",
                column: "TeacherId",
                principalTable: "SchoolUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_SchoolUsers_TeacherId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsToGrades_SchoolUsers_TeacherId",
                table: "StudentsToGrades");

            migrationBuilder.DropIndex(
                name: "IX_StudentsToGrades_TeacherId",
                table: "StudentsToGrades");

            migrationBuilder.DropIndex(
                name: "IX_Absences_TeacherId",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "StudentsToGrades");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Absences");
        }
    }
}
