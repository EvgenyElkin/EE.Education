using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EE.Education.Site.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "education");

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "education",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskEventResultEntity",
                schema: "education",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Comment = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PointCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEventResultEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "education",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    IsTeacher = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskGroups",
                schema: "education",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CourseId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskGroups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "education",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "education",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "education",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentLink",
                schema: "education",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLink", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentLink_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "education",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLink_Users_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "education",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherLink",
                schema: "education",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherLink", x => new { x.CourseId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_TeacherLink_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "education",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherLink_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "education",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                schema: "education",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Cost = table.Column<int>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskGroups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "education",
                        principalTable: "TaskGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskEventDetailsEntity",
                schema: "education",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    DecisionDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: false),
                    ResultId = table.Column<int>(nullable: true),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEventDetailsEntity", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_TaskEventDetailsEntity_Events_EventId",
                        column: x => x.EventId,
                        principalSchema: "education",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskEventDetailsEntity_TaskEventResultEntity_ResultId",
                        column: x => x.ResultId,
                        principalSchema: "education",
                        principalTable: "TaskEventResultEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskEventDetailsEntity_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "education",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                schema: "education",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLink_StudentId",
                schema: "education",
                table: "StudentLink",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEventDetailsEntity_ResultId",
                schema: "education",
                table: "TaskEventDetailsEntity",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEventDetailsEntity_TaskId",
                schema: "education",
                table: "TaskEventDetailsEntity",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskGroups_CourseId",
                schema: "education",
                table: "TaskGroups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_GroupId",
                schema: "education",
                table: "Tasks",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherLink_TeacherId",
                schema: "education",
                table: "TeacherLink",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentLink",
                schema: "education");

            migrationBuilder.DropTable(
                name: "TaskEventDetailsEntity",
                schema: "education");

            migrationBuilder.DropTable(
                name: "TeacherLink",
                schema: "education");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "education");

            migrationBuilder.DropTable(
                name: "TaskEventResultEntity",
                schema: "education");

            migrationBuilder.DropTable(
                name: "Tasks",
                schema: "education");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "education");

            migrationBuilder.DropTable(
                name: "TaskGroups",
                schema: "education");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "education");
        }
    }
}
