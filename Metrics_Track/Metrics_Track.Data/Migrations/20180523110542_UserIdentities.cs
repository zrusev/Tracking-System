using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Metrics_Track.Data.Migrations
{
    public partial class UserIdentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "SequenceIds",
                schema: "CPS",
                startValue: 1000L);

            migrationBuilder.AddColumn<int>(
                name: "ID_Login",
                schema: "CPS",
                table: "AspNetUsers",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR CPS.SequenceIds");

            migrationBuilder.AddColumn<short>(
                name: "Sandbox",
                schema: "CPS",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "SequenceIds",
                schema: "CPS");

            migrationBuilder.DropColumn(
                name: "ID_Login",
                schema: "CPS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sandbox",
                schema: "CPS",
                table: "AspNetUsers");
        }
    }
}
