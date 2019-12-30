using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class UpdatedSubjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "Subjects",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Subjects",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "WeekDay",
                table: "Subjects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "WeekDay",
                table: "Subjects");
        }
    }
}
