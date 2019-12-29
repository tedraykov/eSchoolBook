using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class UniqueConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Pin",
                table: "SchoolUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_SchoolUsers_Pin",
                table: "SchoolUsers",
                column: "Pin");
            
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Classes_ClassTeacherId",
                table: "Classes",
                column: "ClassTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Signature",
                table: "Subjects",
                column: "Signature",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subjects_Signature",
                table: "Subjects");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_SchoolUsers_Pin",
                table: "SchoolUsers");
            
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Classes_ClassTeacherId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Pin",
                table: "SchoolUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
