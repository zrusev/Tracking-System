using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Metrics_Track.Data.Migrations
{
    public partial class AgentRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "CPS",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "CPS",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "trel_AgentCountry",
                schema: "CPS",
                columns: table => new
                {
                    IdAgent = table.Column<string>(nullable: false),
                    IdCountry = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trel_AgentCountry", x => new { x.IdAgent, x.IdCountry });
                    table.ForeignKey(
                        name: "FK_trel_AgentCountry_AspNetUsers_IdAgent",
                        column: x => x.IdAgent,
                        principalSchema: "CPS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trel_AgentCountry_tbl_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalSchema: "CPS",
                        principalTable: "tbl_Country",
                        principalColumn: "ID_Country",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_trel_AgentCountry_IdCountry",
                schema: "CPS",
                table: "trel_AgentCountry",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_trel_AgentMining_IdMining",
                schema: "CPS",
                table: "trel_AgentMining",
                column: "IdMining");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trel_AgentCountry",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "trel_AgentMining",
                schema: "CPS");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "CPS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "CPS",
                table: "AspNetUsers");
        }
    }
}
