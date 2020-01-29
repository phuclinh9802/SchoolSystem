using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageSchool.AspNetCore.NewDb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(nullable: false),
                    ClassName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Error = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    StudentName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    GPA = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ClassId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Display",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(nullable: false),
                    StudentName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    GPA = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ClassName = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    ClassId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Display", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Display_Class_ClassId1",
                        column: x => x.ClassId1,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Display_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Display_ClassId1",
                table: "Display",
                column: "ClassId1");

            migrationBuilder.CreateIndex(
                name: "IX_Display_StudentId",
                table: "Display",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassId",
                table: "Student",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Display");

            migrationBuilder.DropTable(
                name: "Register");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Class");
        }
    }
}
