using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOnline.Migrations
{
    public partial class JepinitTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    RequestedDate = table.Column<DateTimeOffset>(nullable: false),
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_events",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: false),
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_subjects",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_event_details",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    eventsId = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_event_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_t_event_details_tb_m_events_eventsId",
                        column: x => x.eventsId,
                        principalTable: "tb_m_events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_question",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Questions = table.Column<string>(nullable: true),
                    OptionA = table.Column<string>(nullable: true),
                    OptionB = table.Column<string>(nullable: true),
                    OptionC = table.Column<string>(nullable: true),
                    OptionD = table.Column<string>(nullable: true),
                    OptionE = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    isDelete = table.Column<bool>(nullable: false),
                    SubjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_m_question_tb_m_subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "tb_m_subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_examination",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    isDelete = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    RescheduleDate = table.Column<DateTimeOffset>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    ExpiredDate = table.Column<DateTime>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    SubjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_examination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_t_examination_tb_m_subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "tb_m_subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_answer",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    QuestionId = table.Column<string>(nullable: true),
                    Answers = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    isDelete = table.Column<bool>(nullable: false),
                    ExamId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_t_answer_tb_t_examination_ExamId",
                        column: x => x.ExamId,
                        principalTable: "tb_t_examination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_t_answer_tb_m_question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "tb_m_question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_question_SubjectId",
                table: "tb_m_question",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_answer_ExamId",
                table: "tb_t_answer",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_answer_QuestionId",
                table: "tb_t_answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_event_details_eventsId",
                table: "tb_t_event_details",
                column: "eventsId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_examination_SubjectId",
                table: "tb_t_examination",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "tb_t_answer");

            migrationBuilder.DropTable(
                name: "tb_t_event_details");

            migrationBuilder.DropTable(
                name: "tb_t_examination");

            migrationBuilder.DropTable(
                name: "tb_m_question");

            migrationBuilder.DropTable(
                name: "tb_m_events");

            migrationBuilder.DropTable(
                name: "tb_m_subjects");
        }
    }
}
