using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Metrics_Track.Data.Migrations
{
    public partial class TeamLeadName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUsers_TblTeamLead_ID_TeamLead",
            //    schema: "CPS",
            //    table: "AspNetUsers");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_TblTeamLead",
            //    schema: "CPS",
            //    table: "TblTeamLead");

            //migrationBuilder.DropIndex(
            //    name: "IX_AspNetUsers_ID_TeamLead",
            //    schema: "CPS",
            //    table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "TblTeamLead",
                schema: "CPS",
                newName: "tbl_TeamLead");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ID_TeamLead",
            //    schema: "CPS",
            //    table: "AspNetUsers",
            //    nullable: true,
            //    oldClrType: typeof(int));

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_tbl_TeamLead",
            //    schema: "CPS",
            //    table: "tbl_TeamLead",
            //    column: "Id_TeamLead");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUsers_ID_TeamLead",
            //    schema: "CPS",
            //    table: "AspNetUsers",
            //    column: "ID_TeamLead",
            //    unique: true,
            //    filter: "[ID_TeamLead] IS NOT NULL");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUsers_tbl_TeamLead_ID_TeamLead",
            //    schema: "CPS",
            //    table: "AspNetUsers",
            //    column: "ID_TeamLead",
            //    principalSchema: "CPS",
            //    principalTable: "tbl_TeamLead",
            //    principalColumn: "Id_TeamLead",
            //    onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_tbl_TeamLead_ID_TeamLead",
                schema: "CPS",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_TeamLead",
                schema: "CPS",
                table: "tbl_TeamLead");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ID_TeamLead",
                schema: "CPS",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "tbl_TeamLead",
                schema: "CPS",
                newName: "TblTeamLead");

            migrationBuilder.AlterColumn<int>(
                name: "ID_TeamLead",
                schema: "CPS",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblTeamLead",
                schema: "CPS",
                table: "TblTeamLead",
                column: "Id_TeamLead");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ID_TeamLead",
                schema: "CPS",
                table: "AspNetUsers",
                column: "ID_TeamLead",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblTeamLead_ID_TeamLead",
                schema: "CPS",
                table: "AspNetUsers",
                column: "ID_TeamLead",
                principalSchema: "CPS",
                principalTable: "TblTeamLead",
                principalColumn: "Id_TeamLead",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
