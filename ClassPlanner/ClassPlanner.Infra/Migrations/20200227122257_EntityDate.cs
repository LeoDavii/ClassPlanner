using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassPlanner.Infra.Migrations
{
    public partial class EntityDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AlterationDate",
                table: "TeacherInCharge",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "TeacherInCharge",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AlterationDate",
                table: "Teacher",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Teacher",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AlterationDate",
                table: "StudentsClass",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "StudentsClass",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AlterationDate",
                table: "Student",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Student",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AlterationDate",
                table: "EnrolledStudent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "EnrolledStudent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlterationDate",
                table: "TeacherInCharge");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "TeacherInCharge");

            migrationBuilder.DropColumn(
                name: "AlterationDate",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "AlterationDate",
                table: "StudentsClass");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "StudentsClass");

            migrationBuilder.DropColumn(
                name: "AlterationDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AlterationDate",
                table: "EnrolledStudent");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "EnrolledStudent");
        }
    }
}
