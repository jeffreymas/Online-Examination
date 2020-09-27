using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOnline.Migrations
{
    public partial class initTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_answer",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    QuestionId = table.Column<string>(nullable: true),
                    Answers = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_t_answer_tb_m_question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "tb_m_question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_answer_QuestionId",
                table: "tb_t_answer",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_t_answer");

            migrationBuilder.DropTable(
                name: "tb_m_question");
        }
    }
}
