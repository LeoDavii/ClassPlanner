using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassPlanner.Infra.Migrations
{
    public partial class Teacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherInCharge",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    StudentsClassId = table.Column<Guid>(nullable: false),
                    TeacherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherInCharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherInCharge_StudentsClass_StudentsClassId",
                        column: x => x.StudentsClassId,
                        principalTable: "StudentsClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherInCharge_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherInCharge_StudentsClassId",
                table: "TeacherInCharge",
                column: "StudentsClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherInCharge_TeacherId",
                table: "TeacherInCharge",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherInCharge");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
