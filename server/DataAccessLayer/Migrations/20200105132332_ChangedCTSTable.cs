using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class ChangedCTSTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassesToSubjects_Classes_ClassId",
                table: "ClassesToSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesToSubjects_Subjects_SubjectId",
                table: "ClassesToSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_Signature",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassesToSubjects",
                table: "ClassesToSubjects");

            migrationBuilder.DropColumn(
                name: "Signature",
                table: "Subjects");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "ClassesToSubjects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "ClassesToSubjects",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ClassId",
                table: "ClassesToSubjects",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassesToSubjects",
                table: "ClassesToSubjects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClassesToSubjects_ClassId",
                table: "ClassesToSubjects",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesToSubjects_Classes_ClassId",
                table: "ClassesToSubjects",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesToSubjects_Subjects_SubjectId",
                table: "ClassesToSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassesToSubjects_Classes_ClassId",
                table: "ClassesToSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesToSubjects_Subjects_SubjectId",
                table: "ClassesToSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassesToSubjects",
                table: "ClassesToSubjects");

            migrationBuilder.DropIndex(
                name: "IX_ClassesToSubjects_ClassId",
                table: "ClassesToSubjects");

            migrationBuilder.AddColumn<string>(
                name: "Signature",
                table: "Subjects",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "ClassesToSubjects",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassId",
                table: "ClassesToSubjects",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "ClassesToSubjects",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassesToSubjects",
                table: "ClassesToSubjects",
                columns: new[] { "ClassId", "SubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Signature",
                table: "Subjects",
                column: "Signature",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesToSubjects_Classes_ClassId",
                table: "ClassesToSubjects",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesToSubjects_Subjects_SubjectId",
                table: "ClassesToSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
