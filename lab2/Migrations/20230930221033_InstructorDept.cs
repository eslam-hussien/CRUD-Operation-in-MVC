using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class InstructorDept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FK_DeptNo",
                table: "Instructors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_FK_DeptNo",
                table: "Instructors",
                column: "FK_DeptNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_FK_DeptNo",
                table: "Instructors",
                column: "FK_DeptNo",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_FK_DeptNo",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_FK_DeptNo",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "FK_DeptNo",
                table: "Instructors");
        }
    }
}
