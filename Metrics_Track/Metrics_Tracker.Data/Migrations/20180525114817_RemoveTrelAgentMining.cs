using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Metrics_Track.Data.Migrations
{
    public partial class RemoveTrelAgentMining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_tbl_UserActivity_AspNetUsers_IdUserNavigationId",
            //    schema: "CPS",
            //    table: "tbl_UserActivity");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_tbl_Volume_Main_AspNetUsers_IdUserNavigationId",
            //    schema: "CPS",
            //    table: "tbl_Volume_Main");

            migrationBuilder.DropTable(
                name: "trel_AgentMining",
                schema: "CPS");

            //migrationBuilder.DropIndex(
            //    name: "IX_tbl_Volume_Main_IdUserNavigationId",
            //    schema: "CPS",
            //    table: "tbl_Volume_Main");

            //migrationBuilder.DropIndex(
            //    name: "IX_tbl_UserActivity_IdUserNavigationId",
            //    schema: "CPS",
            //    table: "tbl_UserActivity");

            //migrationBuilder.DropColumn(
            //    name: "IdUserNavigationId",
            //    schema: "CPS",
            //    table: "tbl_Volume_Main");

            //migrationBuilder.DropColumn(
            //    name: "IdUserNavigationId",
            //    schema: "CPS",
            //    table: "tbl_UserActivity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUserNavigationId",
                schema: "CPS",
                table: "tbl_Volume_Main",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUserNavigationId",
                schema: "CPS",
                table: "tbl_UserActivity",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "trel_AgentMining",
                schema: "CPS",
                columns: table => new
                {
                    IdAgent = table.Column<string>(nullable: false),
                    IdMining = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trel_AgentMining", x => new { x.IdAgent, x.IdMining });
                    table.ForeignKey(
                        name: "FK_trel_AgentMining_AspNetUsers_IdAgent",
                        column: x => x.IdAgent,
                        principalSchema: "CPS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trel_AgentMining_tbl_Mining_IdMining",
                        column: x => x.IdMining,
                        principalSchema: "CPS",
                        principalTable: "tbl_Mining",
                        principalColumn: "ID_Mining",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Volume_Main_IdUserNavigationId",
                schema: "CPS",
                table: "tbl_Volume_Main",
                column: "IdUserNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserActivity_IdUserNavigationId",
                schema: "CPS",
                table: "tbl_UserActivity",
                column: "IdUserNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_trel_AgentMining_IdMining",
                schema: "CPS",
                table: "trel_AgentMining",
                column: "IdMining");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_UserActivity_AspNetUsers_IdUserNavigationId",
                schema: "CPS",
                table: "tbl_UserActivity",
                column: "IdUserNavigationId",
                principalSchema: "CPS",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Volume_Main_AspNetUsers_IdUserNavigationId",
                schema: "CPS",
                table: "tbl_Volume_Main",
                column: "IdUserNavigationId",
                principalSchema: "CPS",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
