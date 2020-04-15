using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class SubjectsDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "GradeYear", "Name" },
                values: new object[,]
                {
                    { "df52dcbe-5295-4b23-9a46-6f0bb3506143", 1, "Български език и литература" },
                    { "759ad1c7-d32d-48c7-934a-0f88094fb967", 1, "Математика" },
                    { "fa286b3e-0dc5-4969-8fe2-f1d86c655e21", 1, "Околен свят" },
                    { "09b08752-dd73-4bee-bf0d-ec8bda382de1", 1, "Музика" },
                    { "b1af4545-7cf0-4af2-b930-00753b5f02ca", 2, "Български език и литература" },
                    { "0500b5f9-660e-4281-8b9c-6155ab12e30a", 2, "Математика" },
                    { "c4317d70-e215-448c-b34a-ac35c9a91335", 2, "Английски език" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: "0500b5f9-660e-4281-8b9c-6155ab12e30a");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: "09b08752-dd73-4bee-bf0d-ec8bda382de1");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: "759ad1c7-d32d-48c7-934a-0f88094fb967");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: "b1af4545-7cf0-4af2-b930-00753b5f02ca");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: "c4317d70-e215-448c-b34a-ac35c9a91335");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: "df52dcbe-5295-4b23-9a46-6f0bb3506143");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: "fa286b3e-0dc5-4969-8fe2-f1d86c655e21");
        }
    }
}
