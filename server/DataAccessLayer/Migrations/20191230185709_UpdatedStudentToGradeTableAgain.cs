using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class UpdatedStudentToGradeTableAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsToGrades_Grades_GradeId",
                table: "StudentsToGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsToGrades_SchoolUsers_StudentId",
                table: "StudentsToGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsToGrades_Subjects_SubjectId",
                table: "StudentsToGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsToGrades",
                table: "StudentsToGrades");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "StudentsToGrades",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "StudentsToGrades",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "GradeId",
                table: "StudentsToGrades",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "StudentsToGrades",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsToGrades",
                table: "StudentsToGrades",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsToGrades_StudentId",
                table: "StudentsToGrades",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsToGrades_Grades_GradeId",
                table: "StudentsToGrades",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsToGrades_SchoolUsers_StudentId",
                table: "StudentsToGrades",
                column: "StudentId",
                principalTable: "SchoolUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsToGrades_Subjects_SubjectId",
                table: "StudentsToGrades",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsToGrades_Grades_GradeId",
                table: "StudentsToGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsToGrades_SchoolUsers_StudentId",
                table: "StudentsToGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsToGrades_Subjects_SubjectId",
                table: "StudentsToGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsToGrades",
                table: "StudentsToGrades");

            migrationBuilder.DropIndex(
                name: "IX_StudentsToGrades_StudentId",
                table: "StudentsToGrades");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "StudentsToGrades",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "StudentsToGrades",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GradeId",
                table: "StudentsToGrades",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "StudentsToGrades",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsToGrades",
                table: "StudentsToGrades",
                columns: new[] { "StudentId", "GradeId", "SubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsToGrades_Grades_GradeId",
                table: "StudentsToGrades",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsToGrades_SchoolUsers_StudentId",
                table: "StudentsToGrades",
                column: "StudentId",
                principalTable: "SchoolUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsToGrades_Subjects_SubjectId",
                table: "StudentsToGrades",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
