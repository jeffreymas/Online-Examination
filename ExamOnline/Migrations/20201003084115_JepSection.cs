using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOnline.Migrations
{
    public partial class JepSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SectionId",
                table: "tb_m_question",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tb_t_Section",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_Section", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_question_SectionId",
                table: "tb_m_question",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_question_tb_t_Section_SectionId",
                table: "tb_m_question",
                column: "SectionId",
                principalTable: "tb_t_Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_question_tb_t_Section_SectionId",
                table: "tb_m_question");

            migrationBuilder.DropTable(
                name: "tb_t_Section");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_question_SectionId",
                table: "tb_m_question");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "tb_m_question");
        }
    }
}
