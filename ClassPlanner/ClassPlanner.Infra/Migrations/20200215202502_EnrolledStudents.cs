using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassPlanner.Infra.Migrations
{
    public partial class EnrolledStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Student",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Student",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Student",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "StudentsClass",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnrolledStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    StudentsClassId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    RegistrationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolledStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrolledStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolledStudent_StudentsClass_StudentsClassId",
                        column: x => x.StudentsClassId,
                        principalTable: "StudentsClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledStudent_StudentId",
                table: "EnrolledStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledStudent_StudentsClassId",
                table: "EnrolledStudent",
                column: "StudentsClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrolledStudent");

            migrationBuilder.DropTable(
                name: "StudentsClass");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Student");
        }
    }
}
