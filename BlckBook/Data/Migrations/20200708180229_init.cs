using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlckBook.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Avi",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    SchoolId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Province = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Code = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolAddresses_Schools_Id",
                        column: x => x.Id,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TelNo = table.Column<string>(maxLength: 10, nullable: true),
                    FaxNo = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolContacts_Schools_Id",
                        column: x => x.Id,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Streams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SchoolId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streams_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    EmploymentNo = table.Column<string>(nullable: true),
                    IdNo = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DoB = table.Column<DateTime>(nullable: false),
                    EnrollmentDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SchoolId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachers_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    Group = table.Column<string>(maxLength: 1, nullable: false),
                    StreamId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Streams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAddresses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Province = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Code = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherAddresses_Teachers_Id",
                        column: x => x.Id,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherContacts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(maxLength: 10, nullable: true),
                    HomeTel = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherContacts_Teachers_Id",
                        column: x => x.Id,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassTeacher",
                columns: table => new
                {
                    ClassId = table.Column<string>(nullable: false),
                    TeacherId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTeacher", x => new { x.ClassId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_ClassTeacher_Teachers_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassTeacher_Classes_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Content = table.Column<byte[]>(nullable: true),
                    UploadDate = table.Column<DateTime>(nullable: false),
                    SchoolId = table.Column<Guid>(nullable: true),
                    StreamId = table.Column<Guid>(nullable: true),
                    ClassId = table.Column<string>(nullable: true),
                    TeacherId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libraries_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Libraries_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Libraries_Streams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Libraries_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StudNo = table.Column<string>(nullable: true),
                    IdNo = table.Column<string>(nullable: true),
                    DoB = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    EnrollmentDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SchoolId = table.Column<Guid>(nullable: true),
                    ClassId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ClassId = table.Column<string>(nullable: true),
                    TeacherId = table.Column<string>(nullable: true),
                    StreamId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Streams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    DueTime = table.Column<DateTime>(nullable: false),
                    SubmitionOption = table.Column<string>(nullable: false),
                    PostDate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<byte[]>(nullable: true),
                    TeacherId = table.Column<string>(nullable: true),
                    ClassId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Classes_ClassId1",
                        column: x => x.ClassId1,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAddresses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Province = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Code = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAddresses_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentContacts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(maxLength: 10, nullable: true),
                    HomeTel = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentContacts_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    TotalMark = table.Column<double>(nullable: false),
                    CassContribution = table.Column<double>(nullable: false),
                    ClassId = table.Column<string>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Portfolios_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskSubmissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Content = table.Column<byte[]>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskSubmissions_Tasks_Id",
                        column: x => x.Id,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskSubmissions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TotalMark = table.Column<double>(nullable: false),
                    PortfolioId = table.Column<Guid>(nullable: true),
                    StudentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marks_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Marks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_StreamId",
                table: "Classes",
                column: "StreamId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacher_TeacherId",
                table: "ClassTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SchoolId",
                table: "Events",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_ClassId",
                table: "Libraries",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_SchoolId",
                table: "Libraries",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_StreamId",
                table: "Libraries",
                column: "StreamId");

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_TeacherId",
                table: "Libraries",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_PortfolioId",
                table: "Marks",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_StudentId",
                table: "Marks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ClassId",
                table: "Portfolios",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_SubjectId",
                table: "Portfolios",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Streams_SchoolId",
                table: "Streams",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ClassId",
                table: "Subjects",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StreamId",
                table: "Subjects",
                column: "StreamId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ClassId1",
                table: "Tasks",
                column: "ClassId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TeacherId",
                table: "Tasks",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSubmissions_StudentId",
                table: "TaskSubmissions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SchoolId",
                table: "Teachers",
                column: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassTeacher");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "SchoolAddresses");

            migrationBuilder.DropTable(
                name: "SchoolContacts");

            migrationBuilder.DropTable(
                name: "StudentAddresses");

            migrationBuilder.DropTable(
                name: "StudentContacts");

            migrationBuilder.DropTable(
                name: "TaskSubmissions");

            migrationBuilder.DropTable(
                name: "TeacherAddresses");

            migrationBuilder.DropTable(
                name: "TeacherContacts");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Streams");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropColumn(
                name: "Avi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
