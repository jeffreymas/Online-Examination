using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOnline.Migrations
{
    public partial class initEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "tb_t_event_details",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "tb_t_event_details");
        }
    }
}
