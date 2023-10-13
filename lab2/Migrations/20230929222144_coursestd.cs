using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class coursestd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FK_DeptID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CourseDepartment",
                columns: table => new
                {
                    CoursesCourseId = table.Column<int>(type: "int", nullable: false),
                    DepartmentsDeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDepartment", x => new { x.CoursesCourseId, x.DepartmentsDeptId });
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Departments_DepartmentsDeptId",
                        column: x => x.DepartmentsDeptId,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    FK_StudentId = table.Column<int>(type: "int", nullable: false),
                    FK_CourseId = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.FK_StudentId, x.FK_CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_FK_CourseId",
                        column: x => x.FK_CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_FK_StudentId",
                        column: x => x.FK_StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_FK_DeptID",
                table: "Students",
                column: "FK_DeptID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_DepartmentsDeptId",
                table: "CourseDepartment",
                column: "DepartmentsDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_FK_CourseId",
                table: "StudentCourses",
                column: "FK_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_FK_DeptID",
                table: "Students",
                column: "FK_DeptID",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_FK_DeptID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "CourseDepartment");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_Students_FK_DeptID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FK_DeptID",
                table: "Students");
        }
    }
}
