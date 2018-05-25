using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Metrics_Track.Data.Migrations
{
    public partial class TrelCountryMining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trel_CountryMining",
                schema: "CPS",
                columns: table => new
                {
                    IdCountry = table.Column<int>(nullable: false),
                    IdMining = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trel_CountryMining", x => new { x.IdCountry, x.IdMining });
                    table.ForeignKey(
                        name: "FK_trel_CountryMining_tbl_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalSchema: "CPS",
                        principalTable: "tbl_Country",
                        principalColumn: "ID_Country",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trel_CountryMining_tbl_Mining_IdMining",
                        column: x => x.IdMining,
                        principalSchema: "CPS",
                        principalTable: "tbl_Mining",
                        principalColumn: "ID_Mining",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trel_CountryMining_IdMining",
                schema: "CPS",
                table: "trel_CountryMining",
                column: "IdMining");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trel_CountryMining",
                schema: "CPS");
        }
    }
}
