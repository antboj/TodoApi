using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class treca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courseses",
                columns: new[] { "CId", "CName" },
                values: new object[,]
                {
                    { 1, "PHP" },
                    { 2, "Java" },
                    { 3, "C#" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "SId", "SName" },
                values: new object[,]
                {
                    { 1, "Zeus Randolph" },
                    { 2, "Andrej Bojic" },
                    { 3, "John Peters" },
                    { 4, "John Doe" }
                });

            migrationBuilder.InsertData(
                table: "Professorses",
                columns: new[] { "PId", "CId", "PName" },
                values: new object[,]
                {
                    { 1, 1, "Kasimir Cannon" },
                    { 2, 2, "Ria Sims" },
                    { 3, 3, "Regina Hess" }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "SId", "CId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 4, 3 },
                    { 4, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Professorses",
                keyColumn: "PId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professorses",
                keyColumn: "PId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Professorses",
                keyColumn: "PId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "SId", "CId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "SId", "CId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "SId", "CId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "SId", "CId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "SId", "CId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Courseses",
                keyColumn: "CId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courseses",
                keyColumn: "CId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courseses",
                keyColumn: "CId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "SId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "SId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "SId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "SId",
                keyValue: 4);
        }
    }
}
