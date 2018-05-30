using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Metrics_Track.Data.Migrations
{
    public partial class ViewMyDailyTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "SSCViewMyTransactions",
            //    schema: "CPS",
            //    columns: table => new
            //    {
            //        Transaction_ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Activity = table.Column<string>(nullable: true),
            //        AspID_Login = table.Column<int>(nullable: true),
            //        Audit = table.Column<int>(nullable: false),
            //        Comment = table.Column<string>(nullable: true),
            //        CompleteDate = table.Column<DateTime>(nullable: true),
            //        Country = table.Column<string>(nullable: true),
            //        Currency_Code = table.Column<string>(nullable: true),
            //        FunctionName = table.Column<string>(name: "Function Name", nullable: true),
            //        HandlingTime = table.Column<double>(name: "Handling Time", nullable: true),
            //        ID_Login = table.Column<int>(nullable: true),
            //        ID_Number = table.Column<string>(nullable: true),
            //        Lob = table.Column<string>(nullable: true),
            //        Mnc = table.Column<string>(nullable: true),
            //        MultiStepTransaction = table.Column<int>(name: "Multi-Step Transaction", nullable: false),
            //        Premium = table.Column<double>(nullable: true),
            //        Priority = table.Column<short>(nullable: true),
            //        Process = table.Column<string>(nullable: true),
            //        ProcessMap = table.Column<string>(name: "Process Map", nullable: true),
            //        ReceivedDate = table.Column<DateTime>(nullable: true),
            //        SLAAchievment = table.Column<int>(name: "SLA Achievment", nullable: false),
            //        SLAHrs = table.Column<double>(name: "SLA Hrs", nullable: true),
            //        SLATarget = table.Column<int>(name: "SLA Target", nullable: true),
            //        SLATransaction = table.Column<int>(name: "SLA Transaction", nullable: false),
            //        SLAType = table.Column<string>(name: "SLA Type", nullable: true),
            //        StartDate = table.Column<DateTime>(nullable: true),
            //        Status = table.Column<string>(nullable: true),
            //        TeamLeader = table.Column<string>(name: "Team Leader", nullable: true),
            //        UserName = table.Column<string>(name: "User Name", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SSCViewMyTransactions", x => x.Transaction_ID);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SSCViewMyTransactions",
                schema: "CPS");
        }
    }
}
