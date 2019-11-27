using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SchoolBook.DataAccessLayer.Migrations
{
    public partial class ManyToManyFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_SubjectId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Classes_ClassId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_ClassId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParentId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Students",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Schools",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolId",
                table: "Principals",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Principals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Principals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Principals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Principals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "Principals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Principals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Principals",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Parents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Parents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Parents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Parents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "Parents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Parents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Parents",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "ClassTeacherId",
                table: "Classes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Classes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "Absences",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Absences",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Absences",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "ClassesToSubjects",
                columns: table => new
                {
                    ClassId = table.Column<string>(nullable: false),
                    SubjectId = table.Column<string>(nullable: false),
                    WeekDay = table.Column<string>(nullable: true),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesToSubjects", x => new { x.ClassId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_ClassesToSubjects_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassesToSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentToGrade",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    GradeId = table.Column<string>(nullable: false),
                    SubjectId = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentToGrade", x => new { x.StudentId, x.GradeId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentToGrade_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentToGrade_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentToGrade_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherToSubject",
                columns: table => new
                {
                    TeacherId = table.Column<string>(nullable: false),
                    SubjectId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherToSubject", x => new { x.SubjectId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_TeacherToSubject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherToSubject_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassesToSubjects_SubjectId",
                table: "ClassesToSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentToGrade_GradeId",
                table: "StudentToGrade",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentToGrade_SubjectId",
                table: "StudentToGrade",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherToSubject_TeacherId",
                table: "TeacherToSubject",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassesToSubjects");

            migrationBuilder.DropTable(
                name: "StudentToGrade");

            migrationBuilder.DropTable(
                name: "TeacherToSubject");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Principals");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Principals");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Principals");

            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Principals");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Principals");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Principals");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Parents");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Teachers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Subjects",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Subjects",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Subjects",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "Students",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Students",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Students",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Students",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Schools",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "Principals",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Principals",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Parents",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Grades",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Grades",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Grades",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Grades",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "ClassTeacherId",
                table: "Classes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Classes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Absences",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Absences",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Absences",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ClassId",
                table: "Subjects",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_SubjectId",
                table: "Grades",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Classes_ClassId",
                table: "Subjects",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                table: "Subjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
