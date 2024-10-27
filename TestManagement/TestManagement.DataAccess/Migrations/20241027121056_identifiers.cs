using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class identifiers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StepIdentifier",
                table: "TestSteps");

            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "TestSuites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "TestSteps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "TestCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "TestSuites");

            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "TestSteps");

            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "TestCases");

            migrationBuilder.AddColumn<int>(
                name: "StepIdentifier",
                table: "TestSteps",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
