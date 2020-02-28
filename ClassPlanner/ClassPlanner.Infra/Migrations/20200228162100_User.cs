using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassPlanner.Infra.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeacherInChargeId",
                table: "StudentsClass",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsClass_TeacherInChargeId",
                table: "StudentsClass",
                column: "TeacherInChargeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsClass_TeacherInCharge_TeacherInChargeId",
                table: "StudentsClass",
                column: "TeacherInChargeId",
                principalTable: "TeacherInCharge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsClass_TeacherInCharge_TeacherInChargeId",
                table: "StudentsClass");

            migrationBuilder.DropIndex(
                name: "IX_StudentsClass_TeacherInChargeId",
                table: "StudentsClass");

            migrationBuilder.DropColumn(
                name: "TeacherInChargeId",
                table: "StudentsClass");
        }
    }
}
