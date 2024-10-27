using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class testEntitiesRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestSuiteHasLabel_TestLabels_TestLabelId",
                table: "TestSuiteHasLabel");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSuiteHasLabel_TestSuites_TestSuiteId",
                table: "TestSuiteHasLabel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestSuiteHasLabel",
                table: "TestSuiteHasLabel");

            migrationBuilder.DropColumn(
                name: "TestName",
                table: "TestCases");

            migrationBuilder.RenameTable(
                name: "TestSuiteHasLabel",
                newName: "TestSuiteHasLabels");

            migrationBuilder.RenameIndex(
                name: "IX_TestSuiteHasLabel_TestLabelId",
                table: "TestSuiteHasLabels",
                newName: "IX_TestSuiteHasLabels_TestLabelId");

            migrationBuilder.AddColumn<int>(
                name: "TestSuiteId",
                table: "TestCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestSuiteHasLabels",
                table: "TestSuiteHasLabels",
                columns: new[] { "TestSuiteId", "TestLabelId" });

            migrationBuilder.CreateTable(
                name: "TestCaseResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestCaseId = table.Column<int>(type: "int", nullable: false),
                    TestRunStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCaseResults_TestCases_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepIdentifier = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSteps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestCaseHasTestSteps",
                columns: table => new
                {
                    TestCaseId = table.Column<int>(type: "int", nullable: false),
                    TestStepId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCaseHasTestSteps", x => new { x.TestCaseId, x.TestStepId });
                    table.ForeignKey(
                        name: "FK_TestCaseHasTestSteps_TestCases_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestCaseHasTestSteps_TestSteps_TestStepId",
                        column: x => x.TestStepId,
                        principalTable: "TestSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestStepResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestStepId = table.Column<int>(type: "int", nullable: false),
                    TestStepRunResult = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestStepResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestStepResults_TestSteps_TestStepId",
                        column: x => x.TestStepId,
                        principalTable: "TestSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_TestSuiteId",
                table: "TestCases",
                column: "TestSuiteId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseHasTestSteps_TestStepId",
                table: "TestCaseHasTestSteps",
                column: "TestStepId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCaseResults_TestCaseId",
                table: "TestCaseResults",
                column: "TestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TestStepResults_TestStepId",
                table: "TestStepResults",
                column: "TestStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCases_TestSuites_TestSuiteId",
                table: "TestCases",
                column: "TestSuiteId",
                principalTable: "TestSuites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestSuiteHasLabels_TestLabels_TestLabelId",
                table: "TestSuiteHasLabels",
                column: "TestLabelId",
                principalTable: "TestLabels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestSuiteHasLabels_TestSuites_TestSuiteId",
                table: "TestSuiteHasLabels",
                column: "TestSuiteId",
                principalTable: "TestSuites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCases_TestSuites_TestSuiteId",
                table: "TestCases");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSuiteHasLabels_TestLabels_TestLabelId",
                table: "TestSuiteHasLabels");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSuiteHasLabels_TestSuites_TestSuiteId",
                table: "TestSuiteHasLabels");

            migrationBuilder.DropTable(
                name: "TestCaseHasTestSteps");

            migrationBuilder.DropTable(
                name: "TestCaseResults");

            migrationBuilder.DropTable(
                name: "TestStepResults");

            migrationBuilder.DropTable(
                name: "TestSteps");

            migrationBuilder.DropIndex(
                name: "IX_TestCases_TestSuiteId",
                table: "TestCases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestSuiteHasLabels",
                table: "TestSuiteHasLabels");

            migrationBuilder.DropColumn(
                name: "TestSuiteId",
                table: "TestCases");

            migrationBuilder.RenameTable(
                name: "TestSuiteHasLabels",
                newName: "TestSuiteHasLabel");

            migrationBuilder.RenameIndex(
                name: "IX_TestSuiteHasLabels_TestLabelId",
                table: "TestSuiteHasLabel",
                newName: "IX_TestSuiteHasLabel_TestLabelId");

            migrationBuilder.AddColumn<string>(
                name: "TestName",
                table: "TestCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestSuiteHasLabel",
                table: "TestSuiteHasLabel",
                columns: new[] { "TestSuiteId", "TestLabelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TestSuiteHasLabel_TestLabels_TestLabelId",
                table: "TestSuiteHasLabel",
                column: "TestLabelId",
                principalTable: "TestLabels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestSuiteHasLabel_TestSuites_TestSuiteId",
                table: "TestSuiteHasLabel",
                column: "TestSuiteId",
                principalTable: "TestSuites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
