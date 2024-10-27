using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class labels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestLabels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestLabels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectHasTestLabel",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TestLabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectHasTestLabel", x => new { x.ProjectId, x.TestLabelId });
                    table.ForeignKey(
                        name: "FK_ProjectHasTestLabel_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectHasTestLabel_TestLabels_TestLabelId",
                        column: x => x.TestLabelId,
                        principalTable: "TestLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCaseHasTestLabel",
                columns: table => new
                {
                    TestCaseId = table.Column<int>(type: "int", nullable: false),
                    TestLabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseHasTestLabel", x => new { x.TestCaseId, x.TestLabelId });
                    table.ForeignKey(
                        name: "FK_TestCaseHasTestLabel_TestCases_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestCaseHasTestLabel_TestLabels_TestLabelId",
                        column: x => x.TestLabelId,
                        principalTable: "TestLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestSuiteHasLabel",
                columns: table => new
                {
                    TestSuiteId = table.Column<int>(type: "int", nullable: false),
                    TestLabelId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSuiteHasLabel", x => new { x.TestSuiteId, x.TestLabelId });
                    table.ForeignKey(
                        name: "FK_TestSuiteHasLabel_TestLabels_TestLabelId",
                        column: x => x.TestLabelId,
                        principalTable: "TestLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestSuiteHasLabel_TestSuites_TestSuiteId",
                        column: x => x.TestSuiteId,
                        principalTable: "TestSuites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectHasTestLabel_TestLabelId",
                table: "ProjectHasTestLabel",
                column: "TestLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseHasTestLabel_TestLabelId",
                table: "TestCaseHasTestLabel",
                column: "TestLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSuiteHasLabel_TestLabelId",
                table: "TestSuiteHasLabel",
                column: "TestLabelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectHasTestLabel");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "TestCaseHasTestLabel");

            migrationBuilder.DropTable(
                name: "TestSuiteHasLabel");

            migrationBuilder.DropTable(
                name: "TestCases");

            migrationBuilder.DropTable(
                name: "TestLabels");
        }
    }
}
