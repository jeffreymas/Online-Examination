using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOnline.Migrations
{
    public partial class initFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExamId",
                table: "tb_t_answer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubjectId",
                table: "tb_m_question",
                nullable: true);

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
                name: "tb_t_examination",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    isDelete = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    SubjectId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    RescheduleDate = table.Column<DateTimeOffset>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_examination", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_answer_ExamId",
                table: "tb_t_answer",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_question_SubjectId",
                table: "tb_m_question",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_question_tb_m_subjects_SubjectId",
                table: "tb_m_question",
                column: "SubjectId",
                principalTable: "tb_m_subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_t_answer_tb_t_examination_ExamId",
                table: "tb_t_answer",
                column: "ExamId",
                principalTable: "tb_t_examination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_question_tb_m_subjects_SubjectId",
                table: "tb_m_question");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_t_answer_tb_t_examination_ExamId",
                table: "tb_t_answer");

            migrationBuilder.DropTable(
                name: "tb_m_subjects");

            migrationBuilder.DropTable(
                name: "tb_t_examination");

            migrationBuilder.DropIndex(
                name: "IX_tb_t_answer_ExamId",
                table: "tb_t_answer");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_question_SubjectId",
                table: "tb_m_question");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "tb_t_answer");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "tb_m_question");
        }
    }
}
