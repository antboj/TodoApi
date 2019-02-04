using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courseses",
                columns: table => new
                {
                    CId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courseses", x => x.CId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    SId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.SId);
                });

            migrationBuilder.CreateTable(
                name: "Professorses",
                columns: table => new
                {
                    PId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PName = table.Column<string>(nullable: true),
                    CId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professorses", x => x.PId);
                    table.ForeignKey(
                        name: "FK_Professorses_Students_CId",
                        column: x => x.CId,
                        principalTable: "Students",
                        principalColumn: "SId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    SId = table.Column<int>(nullable: false),
                    CId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.SId, x.CId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courseses_CId",
                        column: x => x.CId,
                        principalTable: "Courseses",
                        principalColumn: "CId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_SId",
                        column: x => x.SId,
                        principalTable: "Students",
                        principalColumn: "SId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professorses_CId",
                table: "Professorses",
                column: "CId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CId",
                table: "StudentCourses",
                column: "CId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professorses");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Courseses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
