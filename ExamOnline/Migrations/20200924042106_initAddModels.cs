using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOnline.Migrations
{
    public partial class initAddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "tb_t_event_details",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    eventsId = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_event_details_eventsId",
                table: "tb_t_event_details",
                column: "eventsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_t_event_details");

            migrationBuilder.DropTable(
                name: "tb_m_events");
        }
    }
}
